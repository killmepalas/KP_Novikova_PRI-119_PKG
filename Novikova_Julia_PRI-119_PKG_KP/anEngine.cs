using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novikova_Julia_PRI_119_PKG_KP
{
    public class anLayer
    {
        // размеры экранной области
        public int Width, Heigth;

        // массив , представляющий область рисунка (координаты пикселя и его цвет)
        private int[,,] DrawPlace;

        // флаг видимости слоя: true - видимый, false - невидимый
        private bool isVisible;

        private int ListNom;

        public void PixelTransformation(float[] mat, int corr, float COEFF, bool need_count_correction)
        {
            // массив для получения результирующего пикселя
            float[] resault_RGB = new float[3];
            int count = 0;
            // проходим циклом по всем пикселям слоя
            for (int Y = 0; Y < Heigth; Y++)
            {
                for (int X = 0; X < Width; X++)
                {
                    // цикл по всем составляющим (0-2, т.е. R G B)
                    for (int c = 0, ax = 0, bx = 0; c < 3; c++)
                    {
                        // обнуление составляющей результата
                        resault_RGB[c] = 0;
                        // обнуление счетчика обработок
                        count = 0;

                        // два цикла для захвата области 3х3 вокруг обрабатываемого пикселя
                        for (bx = -1; bx < 2; bx++)
                        {
                            for (ax = -1; ax < 2; ax++)
                            {
                                // если мы не попали в рамки, просто используем центральный пиксель, и продолжаем цикл
                                if (X + ax < 0 || X + ax > Width - 1 || Y + bx < 0 || Y + bx > Heigth - 1)
                                {
                                    // считаем составляющую в одной из точек, используем коэфицент в матрице (под номером текущей итерации), коэфицент усиления (COEFF) и прибовляем коррекцию (corr)
                                    resault_RGB[c] += (float)(DrawPlace[X, Y, c]) * mat[count] * COEFF + corr;
                                    // счетчик обработок = ячейке матрицы с необходимым коэфицентом
                                    count++;
                                    // продолжаем цикл
                                    continue;
                                }

                                // иначе, если мы укладываемся в изображение (не пересекаем границы), используем соседние пиксели, корректируем ячейку массива параметрами ax, bx
                                resault_RGB[c] += (float)(DrawPlace[X + ax, Y + bx, c]) * mat[count] * COEFF + corr;
                                // счетчик обработок = ячейке матрицы с необходимым коэфицентом
                                count++;
                            }
                        }

                    }

                    // теперь для всех составляющих корректируем цвет
                    for (int c = 0; c < 3; c++)
                    {
                        // если требуется разделить результат до приведения к 0-255, разделив на количество проведенных операций
                        if (count != 0 && need_count_correction)
                        {
                            // выполняем данное деление
                            resault_RGB[c] /= count;
                        }

                        // если значение меньше нуля
                        if (resault_RGB[c] < 0)
                        {
                            // - приравниваем к нулю
                            resault_RGB[c] = 0;
                        }

                        // если больше 255
                        if (resault_RGB[c] > 255)
                        {
                            // приравниваем к 255
                            resault_RGB[c] = 255;
                        }
                        // записываем в массив цветов слоя новое значение
                        DrawPlace[X, Y, c] = (int)resault_RGB[c];
                    }
                }
            }

        }

        // инвертирование цветов
        public void Invers()
        {
            // циклами переберам все пиксели изображения
            for (int Y = 0; Y < Heigth; Y++)
            {
                for (int X = 0; X < Width; X++)
                {
                    // и инвертируем цвет, установленный в RGB составляющих, на обратный (255-R) (255-G) (255-B)
                    DrawPlace[X, Y, 0] = 255 - DrawPlace[X, Y, 0];
                    DrawPlace[X, Y, 1] = 255 - DrawPlace[X, Y, 1];
                    DrawPlace[X, Y, 2] = 255 - DrawPlace[X, Y, 2];
                }
            }
        }

        // конструктор класса, в качестве входных параметров
        // мы получаем размеры изображения, чтобы создать в памяти массив,
        // который будет хранить растровые данные для этого слоя

        public anLayer(int s_W, int s_H)
        {
            // запоминаем значения размеров рисунка
            Width = s_W;
            Heigth = s_H;

            // создаем в памяти массив, соотвествующий размерам рисунка
            // каждая точка на полскости массива будет иметь 3 составляющие цвета
            // + 4 ячейка - индикатор того, что данный пиксель пуст (или полность прозрачен)
            DrawPlace = new int[Width, Heigth, 4];



            // проходим по всей плоскости и устанавливаем всем точкам
            // индикатор прозрачности
            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Heigth; bx++)
                {
                    // флаг прозачности точки в координатах ax,bx.
                    DrawPlace[ax, bx, 3] = 1;
                }
            }

            // устанавливаем флаг видимости слоя (по умолчанию создаваемый слой всегда видимый)
            isVisible = true;

        }

    }

    class anEngine
    {
        // размеры изображения
        private int picture_size_x, picture_size_y;

        // положение полос прокрутки будет использовано в будующем
        private int scroll_x, scroll_y;

        // размер оконной части (объекта AnT)
        private int screen_width, screen_height;

        // номер активного слоя
        private int ActiveLayerNom;

        // массив слоев
        private ArrayList Layers = new ArrayList();

        // конструктор класса
        public anEngine(int size_x, int size_y, int screen_w, int screen_h)
        {
            // при инициализации экземпляра класса сохраним настройки
            // размеров элементов и изображения в локальных переменных

            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

            // полосы прокрутки у нас пока отсутствуют, поэтому просто обнулим значение переменных
            scroll_x = 0;
            scroll_y = 0;

            // добавим новый слой для работы, пока что он будет единственным
            Layers.Add(new anLayer(picture_size_x, picture_size_y));

            // номер активного слоя - 0
            ActiveLayerNom = 0;

        }

        public void Filter_2()
        {

            // собираем матрицу
            float[] mat = new float[9];

            mat[0] = 0.05f;
            mat[1] = 0.05f;
            mat[2] = 0.05f;
            mat[3] = 0.05f;
            mat[4] = 0.6f;
            mat[5] = 0.05f;
            mat[6] = 0.05f;
            mat[7] = 0.05f;
            mat[8] = 0.05f;

            //вызываем функцию обработки , передавая туда матрицу и дополнительные параметры
            ((anLayer)Layers[ActiveLayerNom]).PixelTransformation(mat, 0, 1, false);
        }
    }
}
