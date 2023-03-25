using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Novikova_Julia_PRI_119_PKG_KP
{
    public partial class Form1 : Form

    {
        double angle = 3, angleX = -96, angleY = 0, angleZ = -30;
        double sizeX = 1, sizeY = 1, sizeZ = 1;
        double trX = 0.1;

        double translateX = -9, translateY = -60, translateZ = -10;
        float deltaColor;
        double cameraSpeed;

        bool jump = false;
        int countJump = 1;


        double planeTranslateX = 0, planeTranslateZ = 0, planeTranslateDelta = 3;
        double frogTranslateX, frogTranslateY = 0;
        double frogRotateX, frogRotateY = 0;
        double frogScale = 0;
        double frogTranslateDelta = 1;
        bool planeIsIntact = true;
        bool airportIsIntact = true;
        bool flight = false;

        double[] deltaYMushroom = new double[] { -3, -5, -6, -7, -1, -10 };
        double[] deltaXMushroom = new double[] { 0, -5, -1, 2, -4, 0 };

        double deltaYConveer = 0;
        bool mushrooms = false;
        bool winFlag = false;
        bool winMessage = false;

        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        int currentAd;
        double[] baggages = new double[] { 0, 5, 10, 15 };
        // экземпляра класса Explosion
        private readonly Explosion boom = new Explosion(1, 10, 1, 300, 1000);

        // генератор случайны чисел
        Random rnd = new Random();

        bool[] berries = new bool[] { false, false, false, false, false, false };

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                cameraSpeed = (double)numericUpDown1.Value;
            AnT.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnT.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                angle = 3; angleX = -96; angleY = 0; angleZ = -30;
                sizeX = 1; sizeY = 1; sizeZ = 1;
                translateX = -9; translateY = -60; translateZ = -10;
                mushrooms = false;
                button3.Visible = false;
                label10.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                translateX = 0;
                translateY = -100;
                translateZ = -6;
                angleX = -96;
                angleZ = 0;
                mushrooms = false;
                button3.Visible = false;
                label10.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                translateX = 9;
                translateY = -100;
                translateZ = -15;
                angleX = -70;
                angleZ = -90;
                numericUpDown1.Value = 1;
                mushrooms = false;
                button3.Visible = false;
                label10.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                WMP.controls.stop();

            }
            if (comboBox2.SelectedIndex == 3)
            {
                translateX = -10;
                translateY = -50;
                translateZ = -25;
                angleX = -100;
                angleZ = -20;
                numericUpDown1.Value = 1;
                mushrooms = false;
                button3.Visible = false;
                label10.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 4)
            {
                translateX = -10;
                translateY = -140;
                translateZ = -25;
                angleX = -90;
                angleZ = -90;
                numericUpDown1.Value = 1;
                mushrooms = false;
                button3.Visible = false;
                label10.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                WMP.controls.stop();
            }
            if (comboBox2.SelectedIndex == 5)
            {
                translateX = -15;
                translateY = -101;
                translateZ = -8;
                angleX = -57;
                angleZ = -70;
                numericUpDown1.Value = 1;
                mushrooms = true;
                button3.Visible = true;
                label10.Visible = true;
                label15.Visible = true;
                label16.Visible = true;

                WMP.URL = @"frogs.mp3";
                winMessage = false;
                WMP.controls.play();
            }
            winFlag = false;
            AnT.Focus();

        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBox2.SelectedIndex != 1)
            {
                if (e.KeyCode == Keys.W)
                {
                    translateY -= cameraSpeed;

                }
                if (e.KeyCode == Keys.S)
                {
                    translateY += cameraSpeed;
                }
                if (e.KeyCode == Keys.A)
                {
                    translateX += cameraSpeed;
                }
                if (e.KeyCode == Keys.D)
                {
                    translateX -= cameraSpeed;

                }
                if (e.KeyCode == Keys.ControlKey)
                {
                    translateZ += cameraSpeed;

                }
                if (e.KeyCode == Keys.Space)
                {
                    translateZ -= cameraSpeed;
                }
                if (e.KeyCode == Keys.Q)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            angleX += angle;

                            break;
                        case 1:
                            angleY += angle;

                            break;
                        case 2:
                            angleZ += angle;

                            break;
                        default:
                            break;
                    }
                }
                if (e.KeyCode == Keys.E)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            angleX -= angle;
                            break;
                        case 1:
                            angleY -= angle;
                            break;
                        case 2:
                            angleZ -= angle;
                            break;
                        default:
                            break;
                    }
                }
                if (e.KeyCode == Keys.Z)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            sizeX += 0.1;
                            break;
                        case 1:
                            sizeY += 0.1;
                            break;
                        case 2:
                            sizeZ += 0.1;
                            break;
                        default:
                            break;
                    }
                }
                if (e.KeyCode == Keys.X)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            sizeX -= 0.1;
                            break;
                        case 1:
                            sizeY -= 0.1;
                            break;
                        case 2:
                            sizeZ -= 0.1;
                            break;
                        default:
                            break;
                    }
                }

                if (e.KeyCode == Keys.I && planeTranslateZ <= 10 && planeIsIntact)
                {
                    planeTranslateZ += planeTranslateDelta;
                }
                if (e.KeyCode == Keys.K && planeTranslateZ >= -50 && planeIsIntact)
                {
                    planeTranslateZ -= planeTranslateDelta;
                }

                if (e.KeyCode == Keys.F && frogTranslateY >= 0 && mushrooms)
                {
                    frogTranslateY -= frogTranslateDelta;
                    frogRotateY = -90;
                    jump = true;
                }
                if (e.KeyCode == Keys.H && frogTranslateY <= 10 && mushrooms)
                {
                    frogTranslateY += frogTranslateDelta;
                    frogRotateY = 90;
                    jump = true;
                }
                if (e.KeyCode == Keys.T && frogTranslateX >= -10 && mushrooms)
                {
                    frogTranslateX -= frogTranslateDelta;
                    frogRotateY = 180;
                    jump = true;
                }
                if (e.KeyCode == Keys.G && frogTranslateX <= 8 && mushrooms)
                {
                    frogTranslateX += frogTranslateDelta;
                    frogRotateY = 0;
                    jump = true;
                }
            }

        }

        float global_time = 0;
        uint mGlTextureObject;
        uint airportSign;
        int imageId;
        int curAd;
        string[] ads = new string[5] { "owl.jpg", "witch.jpg", "coraline2.jpg", "gravity.jpg", "wonder.jpg" };

        string airport = "airport.png";

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < berries.Length; i++)
                berries[i] = false;
            frogScale = 0;
            winFlag = false;
            winMessage = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flight = true;
            AnT.Focus();
            if (planeTranslateZ < -11)
                button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            airportIsIntact = true;
            deltaColor = 0;
            button2.Enabled = false;
        }

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            if (
                e.X >= 405 && e.X <= 435 && e.Y >= 225 && e.Y <= 240 &&
                comboBox2.SelectedIndex == 1)
            {
                currentAd += 1;
                if (currentAd == 5)
                    currentAd = 0;
                Il.ilGenImages(1, out imageId);
                Il.ilBindImage(imageId);
                if (Il.ilLoadImage(ads[currentAd]))
                {
                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                    switch (bitspp)
                    {
                        case 24:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }
                }
                Il.ilDeleteImages(1, ref imageId);
            }
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            global_time += (float)RenderTimer.Interval / 1000;
            Draw();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.ShowDialog();

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentAd = 0;

            // инициализация openGL (glut)
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // цвет очистки окна
            Gl.glClearColor(255, 255, 255, 1);

            // настройка порта просмотра
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, (float)AnT.Width / (float)AnT.Height, 0.1, 900);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Il.ilGenImages(1, out imageId);
            Il.ilBindImage(imageId);

            if (Il.ilLoadImage(ads[curAd]))
            {
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                {
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            Il.ilDeleteImages(1, ref imageId);

            Il.ilGenImages(1, out imageId);
            Il.ilBindImage(imageId);

            if (Il.ilLoadImage(airport))
            {
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                {
                    case 24:
                        airportSign = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        airportSign = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            Il.ilDeleteImages(1, ref imageId);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            cameraSpeed = 5;
            deltaColor = 0;


            RenderTimer.Start();
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            switch (Format)
            {

                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

            }
            return texObject;
        }


        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glRotated(angleX, 1, 0, 0); Gl.glRotated(angleY, 0, 1, 0); Gl.glRotated(angleZ, 0, 0, 1);
            Gl.glTranslated(translateX, translateY, translateZ);
            Gl.glScaled(sizeX, sizeY, sizeZ);
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            boom.Calculate(global_time);

            //ночь
            Gl.glColor3f(0.13f - deltaColor, 0f - deltaColor, 0.48f - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-100, -10, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, 200, 100);
            Gl.glVertex3d(-100, -10, 100);
            Gl.glEnd();

            Gl.glColor3f(0.13f - deltaColor, 0f - deltaColor, 0.48f - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(200, 200, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, 200, 100);
            Gl.glVertex3d(200, 200, 100);
            Gl.glEnd();

            Gl.glPushMatrix();
            Gl.glColor3f(0.13f - deltaColor, 0f - deltaColor, 0.48f - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(200, 200, 100);
            Gl.glVertex3d(-100, 200, 100);
            Gl.glVertex3d(-100, -10, 100);
            Gl.glVertex3d(200, -10, 100);
            Gl.glEnd();

            //трава
            Gl.glColor3f(0.0625f - deltaColor, 0.46f - deltaColor, 0.1f - deltaColor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(200, 200, 0);
            Gl.glVertex3d(-100, 200, 0);
            Gl.glVertex3d(-100, -10, 0);
            Gl.glVertex3d(200, -10, 0);
            Gl.glEnd();

            //аэропорт
            if (airportIsIntact)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(-80, 140, 25);
                Gl.glScaled(3, 6, 6);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-80, 180, 15);
                Gl.glScaled(3, 2, 3);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-80, 100, 15);
                Gl.glScaled(3, 2, 3);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                //окна

                double windowDeltaY = 0;
                double windowDeltaZ = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Gl.glPushMatrix();
                        Gl.glTranslated(-56, 124 + windowDeltaY, 35 - windowDeltaZ);
                        Gl.glColor3f(0.91f - deltaColor, 0.95f - deltaColor, 0.33f - deltaColor);
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glVertex3d(-8, 0, 0);
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3d(-8, -8, 0);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3d(-8, -8, 8);
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3d(-8, 0, 8);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glEnd();
                        Gl.glPopMatrix();
                        windowDeltaY += 20;
                    }
                    windowDeltaY = 0;
                    windowDeltaZ += 13;
                }

                //вывеска
                Gl.glPushMatrix();
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, airportSign);

                Gl.glPushMatrix();
                Gl.glTranslated(-64, 140, 44.5);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex3d(0, 20, 0);
                Gl.glTexCoord2f(0, 0);
                Gl.glVertex3d(0, -20, 0);
                Gl.glTexCoord2f(0, 1);
                Gl.glVertex3d(0, -20, 8.5);
                Gl.glTexCoord2f(1, 1);
                Gl.glVertex3d(0, 20, 8.5);
                Gl.glTexCoord2f(1, 0);
                Gl.glEnd();
                Gl.glPopMatrix();

                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glPopMatrix();
            }
            else
            {
                Gl.glPushMatrix();
                Gl.glTranslated(-80, 120, 20);
                Gl.glScaled(3, 2, 4);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);

                Gl.glTranslated(0, 7, -2);
                Gl.glScaled(1, 0.5, 0.7);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);

                Gl.glTranslated(0, 18, -2);
                Gl.glScaled(1, 2.7, 0.5);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-80, 180, 15);
                Gl.glScaled(3, 2, 3);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-60, 150, 2.9);
                Gl.glScaled(1, 1, 0.7);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(8);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(8);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-60, 158, 4);
                Gl.glScaled(1, 1, 1.3);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(8);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(8);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-53, 158, 1);
                Gl.glScaled(0.5, 1, 0.5);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(5);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(5);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-80, 100, 15);
                Gl.glScaled(3, 2, 3);
                Gl.glColor3f(0.47f - deltaColor, 0.52f - deltaColor, 0.48f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                double windowDeltaZ = 0;
                for (int i = 0; i < 2; i++)
                {
                    Gl.glPushMatrix();
                    Gl.glTranslated(-56, 122, 22 - windowDeltaZ);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex3d(-8, 0, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(-8, -8, 0);
                    Gl.glTexCoord2f(0, 1);
                    Gl.glVertex3d(-8, -8, 8);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(-8, 0, 8);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glEnd();
                    Gl.glPopMatrix();
                    windowDeltaZ += 13;
                }
            }



            Gl.glPushMatrix();
            Gl.glTranslated(-40, 100, 0);
            Gl.glScaled(1, 2.5, 3);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-31.3, 110, 0);
            Gl.glScaled(0.7, 0.5, 2);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-31.3, 90, 0);
            Gl.glScaled(0.7, 0.5, 2);
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.7f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-31.3, 100, 0);
            Gl.glScaled(0.5, 1.5, 0.5);
            Gl.glColor3f(0.13f - deltaColor, 0.13f - deltaColor, 0.13f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();



            Gl.glPushMatrix();
            Gl.glTranslated(-33.3, 107.3, 2.8);
            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 0, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, 0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(5, 0, 6);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 6);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-33.3, 92.8, 2.8);
            Gl.glColor3f(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 0, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(5, 0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(5, 0, 6);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 6);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

            for (int i = 0; i < baggages.Length; i++)
            {
                if (baggages[i] + 90 > 110)
                {
                    baggages[i] = 0;
                }
                Gl.glPushMatrix();
                Gl.glTranslated(-30, 90 + baggages[i], 5);
                Gl.glScaled(0.2, 0.4, 0.3 + i / 30f);
                Gl.glColor3f(0, i / 4f, 0.6f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                //ручка багажа
                Gl.glPushMatrix();
                Gl.glTranslated(-30, 89 + baggages[i], 7);
                Gl.glScaled(0.02, 0.02, 0.1);
                Gl.glColor3f(0f - deltaColor, 0f - deltaColor, 0f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-30, 91 + baggages[i], 7);
                Gl.glScaled(0.02, 0.02, 0.1);
                Gl.glColor3f(0f - deltaColor, 0f - deltaColor, 0f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glTranslated(-30, 90 + baggages[i], 7.8);
                Gl.glScaled(0.02, 0.2, 0.02);
                Gl.glColor3f(0f - deltaColor, 0f - deltaColor, 0f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();
                baggages[i] += 0.15;
            }

            Gl.glPushMatrix();
            Gl.glTranslated(-33, 100, 3);
            Gl.glColor3f(0 - deltaColor, 0 - deltaColor, 0 - deltaColor);

            for (int j = 0; j < 6; j++)
            {
                if (deltaYConveer == 14) deltaYConveer = 0;
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3d(0, -5 + deltaYConveer, 0);
                Gl.glVertex3d(4.5, -5 + deltaYConveer, 0);
                Gl.glEnd();
                deltaYConveer += 2;
            };
            Gl.glPopMatrix();



            if (!flight)
            {
                if (planeIsIntact)
                {
                    //самолёт
                    Gl.glPushMatrix();
                    Gl.glTranslated(-20, 170, 70 + planeTranslateZ);

                    //перед
                    Gl.glPushMatrix();
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(-90, 0, 1, 0);
                    Gl.glColor3f(0.9f - deltaColor, 0.9f - deltaColor, 0.9f - deltaColor);
                    Glut.glutSolidCone(5, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 10, 32, 32);

                    //тело
                    Gl.glTranslated(0, 0, -40);
                    Gl.glScaled(1, 1, 1);
                    Gl.glColor3f(0.9f - deltaColor, 0.9f - deltaColor, 0.9f - deltaColor);
                    Glut.glutSolidCylinder(5, 40, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(5, 40, 32, 32);
                    Gl.glPopMatrix();

                    //левое крыло
                    Gl.glPushMatrix();
                    Gl.glTranslated(15, 0, -1);
                    Gl.glScaled(2, 1.5, 0.2);
                    Gl.glRotated(90, 1, 0, 0);
                    Gl.glRotated(60, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(5, 15, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 15, 32, 32);
                    Gl.glPopMatrix();

                    //правое крыло
                    Gl.glPushMatrix();
                    Gl.glTranslated(15, 0, -1);
                    Gl.glScaled(2, 1.5, 0.2);
                    Gl.glRotated(-90, 1, 0, 0);
                    Gl.glRotated(60, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(5, 15, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 15, 32, 32);
                    Gl.glPopMatrix();

                    //зад
                    Gl.glPushMatrix();
                    Gl.glTranslated(38.5, 0, -1.3);
                    Gl.glScaled(0.5, 1, 1);
                    Gl.glRotated(40, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(4.8, 20, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(4.8, 20, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(41.5, 0.5, 7);
                    Gl.glScaled(0.2, 0.7, 0.1);
                    Gl.glRotated(40, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidSphere(12, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireSphere(12, 32, 32);
                    Gl.glPopMatrix();

                    //турбина левая
                    Gl.glPushMatrix();
                    Gl.glTranslated(22, -7, -3);
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(90, 0, 1, 0);
                    Gl.glColor3f(0.2f - deltaColor, 0.2f - deltaColor, 0.2f - deltaColor);
                    Glut.glutSolidCylinder(2, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(2, 10, 32, 32);
                    Gl.glPopMatrix();

                    //правая турбина
                    Gl.glTranslated(22, 4, -3);
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(90, 0, 1, 0);
                    Gl.glColor3f(0.2f - deltaColor, 0.2f - deltaColor, 0.2f - deltaColor);
                    Glut.glutSolidCylinder(2, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(2, 10, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPopMatrix();
                }

            }
            else
            {
                if ((trX > 40) && (planeTranslateZ < -11))
                {
                    airportIsIntact = false;
                    planeIsIntact = false;
                    flight = false;
                    trX = 0.1;
                    deltaColor = 0.3f;

                    boom.SetNewPosition(-25, 100, 16);
                    boom.SetNewPower(100);
                    boom.Boooom(global_time);
                }
                else if (trX > 70)
                {
                    flight = false;
                    trX = 0.1;
                }
                else
                {
                    //самолёт
                    Gl.glPushMatrix();
                    Gl.glTranslated(-20 - trX, 170, 70 + planeTranslateZ);

                    //перед
                    Gl.glPushMatrix();
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(-90, 0, 1, 0);
                    Gl.glColor3f(0.9f - deltaColor, 0.9f - deltaColor, 0.9f - deltaColor);
                    Glut.glutSolidCone(5, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 10, 32, 32);

                    //тело
                    Gl.glTranslated(0, 0, -40);
                    Gl.glScaled(1, 1, 1);
                    Gl.glColor3f(0.9f - deltaColor, 0.9f - deltaColor, 0.9f - deltaColor);
                    Glut.glutSolidCylinder(5, 40, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(5, 40, 32, 32);
                    Gl.glPopMatrix();

                    //левое крыло
                    Gl.glPushMatrix();
                    Gl.glTranslated(15, 0, -1);
                    Gl.glScaled(2, 1.5, 0.2);
                    Gl.glRotated(90, 1, 0, 0);
                    Gl.glRotated(60, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(5, 15, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 15, 32, 32);
                    Gl.glPopMatrix();

                    //правое крыло
                    Gl.glPushMatrix();
                    Gl.glTranslated(15, 0, -1);
                    Gl.glScaled(2, 1.5, 0.2);
                    Gl.glRotated(-90, 1, 0, 0);
                    Gl.glRotated(60, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(5, 15, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(5, 15, 32, 32);
                    Gl.glPopMatrix();

                    //зад
                    Gl.glPushMatrix();
                    Gl.glTranslated(38.5, 0, -1.3);
                    Gl.glScaled(0.5, 1, 1);
                    Gl.glRotated(40, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidCone(4.8, 20, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCone(4.8, 20, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(41.5, 0.5, 7);
                    Gl.glScaled(0.2, 0.7, 0.1);
                    Gl.glRotated(40, 0, 1, 0);
                    Gl.glColor3f(0.4f - deltaColor, 0.7f - deltaColor, 1f - deltaColor);
                    Glut.glutSolidSphere(12, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireSphere(12, 32, 32);
                    Gl.glPopMatrix();

                    //турбина левая
                    Gl.glPushMatrix();
                    Gl.glTranslated(22, -7, -3);
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(90, 0, 1, 0);
                    Gl.glColor3f(0.2f - deltaColor, 0.2f - deltaColor, 0.2f - deltaColor);
                    Glut.glutSolidCylinder(2, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(2, 10, 32, 32);
                    Gl.glPopMatrix();

                    //правая турбина
                    Gl.glTranslated(22, 4, -3);
                    Gl.glScaled(1, 1, 1);
                    Gl.glRotated(90, 0, 1, 0);
                    Gl.glColor3f(0.2f - deltaColor, 0.2f - deltaColor, 0.2f - deltaColor);
                    Glut.glutSolidCylinder(2, 10, 32, 32);
                    Gl.glColor3f(0, 0, 0);
                    Gl.glLineWidth(5f);
                    Glut.glutWireCylinder(2, 10, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPopMatrix();
                    trX += 3;
                }
            }

            //табло баннера
            Gl.glPushMatrix();
            Gl.glTranslated(0, 120, 13);
            Gl.glScaled(2, 0.02, 1);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();


            //ножка баннера
            Gl.glPushMatrix();
            Gl.glTranslated(0, 120, 4);
            Gl.glScaled(0.1, 0.02, 0.8);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            //кнопка вперёд
            Gl.glPushMatrix();
            Gl.glTranslated(8, 119, 8.5);
            Gl.glScaled(0.1, 0.02, 0.05);
            Gl.glColor3f(0.79f - deltaColor, 0f - deltaColor, 0f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            //реклама
            Gl.glPushMatrix();
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);


            Gl.glPushMatrix();
            Gl.glTranslated(0, 119, 9);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-8, 0, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(8, 0, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(8, 0, 8);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-8, 0, 8);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(1, 1, 1);
            Gl.glTranslated(-36, 96.8, 7);
            Gl.glLineWidth(3f);
            Gl.glScaled(0.5, 0.07, 0.07);
            Gl.glRotated(90, 0, 1, 0);
            Gl.glRotated(90, 0, 0, 1);
            Gl.glTranslated(-4, 5, 3);
            Gl.glBegin(Gl.GL_LINES);
            drowLevy(0, 0, 100, 0, 15); //вызов функции вырисовки
            Gl.glEnd();
            Gl.glPopMatrix();


            //лягух
            Gl.glPushMatrix();
            if (jump)
            {
                if (countJump <= 10)
                {
                    if (countJump < 6)
                        Gl.glTranslated(0 + frogTranslateX - frogTranslateDelta + frogTranslateDelta * countJump / 10, 100 + frogTranslateY - frogTranslateDelta + frogTranslateDelta * countJump / 10, 1.5 + 0.2 * countJump);
                    else Gl.glTranslated(0 + frogTranslateX - frogTranslateDelta + frogTranslateDelta * countJump / 10, 100 + frogTranslateY - frogTranslateDelta + frogTranslateDelta * countJump / 10, 1.5 - 0.2 * (countJump - 5));
                    countJump++;
                }
                else
                {
                    countJump = 0;
                    jump = false;
                }

            }
            else
            {
                Gl.glTranslated(0 + frogTranslateX, 100 + frogTranslateY, 1.5);
            }

            Gl.glRotated(frogRotateY, 0, 0, 1);
            Gl.glScaled(1.5 + frogScale, 1 + frogScale, 1 + frogScale);

            //тело
            Gl.glPushMatrix();
            Gl.glScaled(1, 1.5, 1.1);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            //левый глаз
            Gl.glPushMatrix();
            Gl.glTranslated(0.3, -0.7, 1.1);
            Gl.glScaled(0.5, 1, 1.1);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(0.3, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.3, 32, 32);

            Gl.glTranslated(0.15, 0, 0.03);
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(1, 1, 1);
            Glut.glutSolidSphere(0.25, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.25, 32, 32);

            Gl.glTranslated(0.2, 0, 0.05);
            Gl.glScaled(1, 1, 1);
            Glut.glutSolidSphere(0.1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(0.1, 32, 32);
            Gl.glPopMatrix();

            //правый глаз
            Gl.glPushMatrix();
            Gl.glTranslated(0.3, 0.7, 1.1);
            Gl.glScaled(0.5, 1, 1.1);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(0.3, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.3, 32, 32);

            Gl.glTranslated(0.15, 0, 0.03);
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(1, 1, 1);
            Glut.glutSolidSphere(0.25, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.25, 32, 32);

            Gl.glTranslated(0.2, 0, 0.05);
            Gl.glScaled(1, 1, 1);
            Glut.glutSolidSphere(0.1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(0.1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.9, -0.15, 0.5);
            Gl.glScaled(0.5, 0.005, 0.7);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidSphere(0.15, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.15, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.9, 0.15, 0.5);
            Gl.glScaled(0.5, 0.005, 0.7);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidSphere(0.15, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(0.15, 32, 32);
            Gl.glPopMatrix();

            //правая передняя лапка
            Gl.glPushMatrix();
            Gl.glTranslated(0.4, 1, -0.5);
            Gl.glScaled(0.3, 0.3, 0.7);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.5, -1.1, -1);
            Gl.glScaled(0.3, 0.2, 0.3);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            //левая передняя лапка
            Gl.glPushMatrix();
            Gl.glTranslated(0.4, -1, -0.5);
            Gl.glScaled(0.3, 0.3, 0.7);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.5, 1.1, -1);
            Gl.glScaled(0.3, 0.2, 0.3);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            //левая задняя лапка
            Gl.glPushMatrix();
            Gl.glTranslated(-0.3, -1, -0.5);
            Gl.glRotated(45, 0, 1, 0);
            Gl.glScaled(0.3, 0.3, 0.7);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-0.3, -1, -1);
            Gl.glRotated(20, 0, 1, 0);
            Gl.glScaled(0.5, 0.3, 0.25);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            //правая задняя лапка
            Gl.glPushMatrix();
            Gl.glTranslated(-0.3, 1, -0.5);
            Gl.glRotated(45, 0, 1, 0);
            Gl.glScaled(0.3, 0.3, 0.7);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-0.3, 1, -1);
            Gl.glRotated(20, 0, 1, 0);
            Gl.glScaled(0.5, 0.3, 0.25);
            Gl.glColor3f(0, 1f - deltaColor, 0);
            Glut.glutSolidSphere(1, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(1f);
            Glut.glutWireSphere(1, 32, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(1, 0, -0.2);
            Gl.glLineWidth(3f);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(-0.01, 0.5, 0.5);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(-0.01, -0.5, 0.5);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPopMatrix();

            if (mushrooms)
            {
                for (int i = 0; i < 6; i++)
                {

                    if (0 + frogTranslateX < 10 + deltaXMushroom[i] && 0 + frogTranslateX > 4 + deltaXMushroom[i] &&
                        100 + frogTranslateY < 112 + deltaYMushroom[i] && 100 + frogTranslateY > 108 + deltaYMushroom[i])
                    {
                        if (!berries[i])
                        {
                            frogScale += 0.1;
                        }
                        berries[i] = true;
                    }

                    if (!berries[i])
                    {
                        Gl.glPushMatrix();
                        Gl.glTranslated(7 + deltaXMushroom[i], 110 + deltaYMushroom[i], 1);
                        Gl.glScaled(0.25, 0.25, 0.35);
                        Gl.glColor3f(0.83f - deltaColor, 0.82f - deltaColor, 0.66f - deltaColor);
                        Glut.glutSolidSphere(1, 32, 32);
                        Gl.glColor3f(0, 0, 0);
                        Gl.glLineWidth(1f);
                        Glut.glutWireSphere(1, 32, 32);
                        Gl.glPopMatrix();

                        Gl.glPushMatrix();
                        Gl.glTranslated(7 + deltaXMushroom[i], 110 + deltaYMushroom[i], 1.35);
                        Gl.glScaled(0.4, 0.4, 0.2);
                        Gl.glColor3f(0.27f - deltaColor, 0.11f - deltaColor, 0.04f - deltaColor);
                        Glut.glutSolidSphere(1, 32, 32);
                        Gl.glColor3f(0, 0, 0);
                        Gl.glLineWidth(1f);
                        Glut.glutWireSphere(1, 32, 32);
                        Gl.glPopMatrix();

                    }
                }

                foreach (bool mr in berries)
                {
                    if (mr == false)
                    {
                        winFlag = true;
                        break;
                    }
                }
                if ((!winMessage)&&(!winFlag))
                {
                    winMessage = true;
                    MessageBox.Show("Вы победили!");
                    
                }
                winFlag = false;
            }



            Gl.glPopMatrix();

            Gl.glFlush();
            AnT.Invalidate();

        }

        void drowLevy(int x1, int y1, int x2, int y2, int i)
        {
            if (i == 0)
            {
                Gl.glColor3f(0, 0, 0);
                Gl.glVertex2i(x1, y1); //координаты вырисовываемого 
                Gl.glVertex2i(x2, y2); //отрезка
            }
            else
            {
                int x3 = (x1 + x2) / 2 - (y2 - y1) / 2; //координаты
                int y3 = (y1 + y2) / 2 + (x2 - x1) / 2; //точки излома
                drowLevy(x1, y1, x3, y3, i - 1);
                drowLevy(x3, y3, x2, y2, i - 1);
            }
        }

    }
}