// gk3d1111.cpp : Defines the entry point for the console application.

//

#include "stdafx.h"


#include <stdlib.h>

#include "glut.h"


//#include <GL/glut.h>

#include <stdlib.h>

#define _USE_MATH_DEFINES
#include <math.h>

// stała do obsługi menu podręcznego

enum

{

	EXIT // wyjście

};

double PredkoscKamery = 0;

// pionowy kąt pola widzenia

GLdouble fovy = 60;

float czajnikrot = 0;

// wpółrzędne położenia obserwatora

GLdouble eyex = 0;

GLdouble eyey = 0;

GLdouble eyez = 3;

GLdouble ObrotX = 3.14 / 2.0;

GLdouble ObrotY = 0;

bool KeyUP = false;

bool KeyDOWN = false;

bool KeyRIGHT = false;

bool KeyLEFT = false;

// współrzędne punktu w którego kierunku jest zwrócony obserwator,

GLdouble centerx = 0;

GLdouble centery = 0;

GLdouble centerz = -100;

int figure = 0;

float kat = 0;

GLuint idlisty;

// funkcja generująca scenę 3D

void GenerujListyWyswietlania()

{

	idlisty = glGenLists(4);

	// utworzenie pierwszej listy

	glNewList(idlisty + 0, GL_COMPILE);

	glTranslatef(0, 0, 10);

	glutWireCube(1);

	glEndList();

	// utworzenie drugiej listy

	glNewList(idlisty + 1, GL_COMPILE);

	glTranslatef(0, 0, 8);

	glutWireTeapot(1);

	glTranslatef(0, 0, 10);

	glutWireTeapot(1);

	glTranslatef(0, 0, 10);

	//glutWireTeapot(1);

	int n = 6;
	float alfa = 0;
	float x, y;
	float dalfa = 2 * M_PI / n;
	glColor3f(1, 0, 0);

	glBegin(GL_TRIANGLE_FAN);


	for (int i = 0; i < n; i++) {
		x = 3 * cos(alfa);
		y = 3 * sin(alfa);


		glVertex3f(x, y, 0);

		alfa += dalfa;
	}
	glEnd();
	glTranslatef(0, 0, 5);



	alfa = 0;
	dalfa = 2 * M_PI / n;
	glColor3f(0, 1, 0);

	glBegin(GL_TRIANGLE_FAN);

	for (int i = 0; i < n; i++) {
		x = 3 * cos(alfa);
		y = 3 * sin(alfa);


		glVertex3f(x, y, 0);

		alfa += dalfa;
	}
	glEnd();



	glColor3f(0.8, 0, 1);
	glBegin(GL_TRIANGLE_STRIP);


	for (int i = 0; i <= n; i++) {
		x = 3 * cos(alfa);
		y = 3 * sin(alfa);


		glVertex3f(x, y, 0);
		glVertex3f(x, y, -5);

		alfa += dalfa;
	}
	glEnd();


	n = 50;
	alfa = 0;
	dalfa = 2 * M_PI / n;
	glColor3f(1, 0, 0.5);

	glBegin(GL_TRIANGLE_FAN);


	for (int i = 0; i < n; i++) {
		x = 1 * cos(alfa);
		y = 1 * sin(alfa);

		glVertex3f(x, y, 10);
		alfa += dalfa;
	}
	glEnd();
	



	glColor3f(1, 0, 0.5);

	glBegin(GL_TRIANGLE_FAN);


	for (int i = 0; i < n; i++) {
		x = 1 * cos(alfa);
		y = 1 * sin(alfa);

		glVertex3f(x, y, -10);
		alfa += dalfa;
	}
	glEnd();





	glColor3f(0.5, 0, 1);
	glBegin(GL_TRIANGLE_STRIP);


	for (int i = 0; i <= n; i++) {
		x = 1 * cos(alfa);
		y = 1 * sin(alfa);


		glVertex3f(x, y, -10);
		glVertex3f(x, y, 10);

		alfa += dalfa;
	}
	glEnd();






	glEndList();

	// utworzenie trzeciej listy

	glNewList(idlisty + 2, GL_COMPILE);

	glTranslatef(0, 0, 10);

	glutWireCone(1, 1, 10, 10);

	glEndList();

}

void UstawKamere() {

	double cosx, siny, sinx;

	double CelX, CelY, CelZ;

	// wartości funkcji trygonometrycznych

	// obliczamy tylko raz dla oszczędności

	if (KeyDOWN) PredkoscKamery = -0.01;

	if (KeyUP) PredkoscKamery = 0.01;

	if (KeyLEFT) ObrotX -= 0.01;

	if (KeyRIGHT) ObrotX += 0.01;

	siny = sin(ObrotY);

	cosx = cos(ObrotX);

	sinx = sin(ObrotX);

	// nowa pozycja kamery

	eyex += cosx * PredkoscKamery;

	eyey += siny * PredkoscKamery;

	eyez += sinx * PredkoscKamery;

	// punkt wycelowania kamery powinien

	// znajdować się gdzieś "przed jej nosem"

	CelX = eyex + cosx;

	CelY = eyey + siny;

	CelZ = eyez + sinx;

	gluLookAt(eyex, eyey, eyez, CelX, CelY, CelZ, 0, 1, 0);

	//gluLookAt( eyex, eyey, eyez, centerx, centery, centerz, 0, 1, 0 );

	PredkoscKamery = 0;

}

void Display()

{

	// kolor tła - zawartość bufora koloru

	glClearColor(1.0, 1.0, 1.0, 1.0);

	// czyszczenie bufora koloru

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glEnable(GL_DEPTH_TEST);

	// wybór macierzy modelowania

	glMatrixMode(GL_MODELVIEW);

	// macierz modelowania = macierz jednostkowa

	glLoadIdentity();

	UstawKamere();

	// ustawienie obserwatora

	//glRotatef(kat,1,0,0);

	// przesunięcie obiektu o wektor [0,0,-3]

	//glTranslatef( 0, 0, 2.0 );

	// kolor krawędzi sześcianu

	glColor3f(0.7, 0.0, 1.0);

	// glutWireCube(1);

	switch (figure)

	{

	case 1:

		glCallList(idlisty + 0);

		break;

	case 2:

		glCallList(idlisty + 1);

		break;

	case 3:

		glCallList(idlisty + 2);

		break;

	}

	// skierowanie poleceń do wykonania

	glFlush();

	// zamiana buforów koloru

	glutSwapBuffers();

}

// zmiana wielkości okna

void Reshape(int width, int height)

{

	// obszar renderingu - całe okno

	glViewport(0, 0, width, height);

	// wybór macierzy rzutowania

	glMatrixMode(GL_PROJECTION);

	// macierz rzutowania = macierz jednostkowa

	glLoadIdentity();

	// obliczenie aspektu obrazu z uwzględnieniem

	// przypadku, gdy wysokość obrazu wynosi 0

	GLdouble aspect = 1;

	if (height > 0)

		aspect = width / (GLdouble)height;

	// rzutowanie perspektywiczne

	gluPerspective(fovy, aspect, 0.01, 100.0);

	// generowanie sceny 3D

	Display();

}

// obsługa klawiatury

void Klawisze(unsigned char key, int x, int y)

{

	// klawisz +

	if (key == '+' && fovy < 180)

		fovy++;

	// klawisz -

	if (key == '-' && fovy > 0)

		fovy--;

	if (key == 'a' && fovy > 0)

		kat++;

	if (key == 'w')

		PredkoscKamery = 0.02;

	if (key == 's')

		PredkoscKamery = -0.02;

	if (key == 'e')

		ObrotX += 0.02;

	if (key == 'q')

		ObrotX -= 0.02;

	if (key == 'r')

		ObrotY += 0.02;

	if (key == 'f')

		ObrotY -= 0.02;

	// odrysowanie okna

	Reshape(glutGet(GLUT_WINDOW_WIDTH), glutGet(GLUT_WINDOW_HEIGHT));

}

void KlawiszeSpecjalne(int key, int x, int y)

{

	switch (key)

	{

		// kursor w lewo

	case GLUT_KEY_LEFT:

		eyex += 0.1;

		break;

		// kursor w górę

	case GLUT_KEY_UP:

		eyey -= 0.1;

		break;

		// kursor w prawo

	case GLUT_KEY_RIGHT:

		eyex -= 0.1;

		break;

		// kursor w dół

	case GLUT_KEY_DOWN:

		eyey += 0.1;

		break;

	}

	// odrysowanie okna

	Reshape(glutGet(GLUT_WINDOW_WIDTH), glutGet(GLUT_WINDOW_HEIGHT));

}

// obsługa menu podręcznego

void Menu(int value)

{

	switch (value)

	{

		// wyjście

	case EXIT:

		exit(0);

		// wyjście

	case 1:

		figure = 1;

		break;

	case 2:

		figure = 2;

		break;

	case 3:

		figure = 3;

		break;

	}

	Reshape(glutGet(GLUT_WINDOW_WIDTH), glutGet(GLUT_WINDOW_HEIGHT));

}

void KeyDown(int key, int x, int y) {

	switch (key) {

	case GLUT_KEY_UP:

		KeyUP = true;

		break;

	case GLUT_KEY_DOWN:

		KeyDOWN = true;

		break;

	case GLUT_KEY_LEFT:

		KeyLEFT = true;

		break;

	case GLUT_KEY_RIGHT:

		KeyRIGHT = true;

		break;

	}

}

void KeyUp(int key, int x, int y) {

	switch (key) {

	case GLUT_KEY_UP:

		KeyUP = false;

		break;

	case GLUT_KEY_DOWN:

		KeyDOWN = false;

		break;

	case GLUT_KEY_LEFT:

		KeyLEFT = false;

		break;

	case GLUT_KEY_RIGHT:

		KeyRIGHT = false;

		break;

	}

}

int main(int argc, char * argv[])

{

	// inicjalizacja biblioteki GLUT

	glutInit(&argc, argv);

	// inicjalizacja bufora ramki

	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);

	// rozmiary głównego okna programu

	glutInitWindowSize(400, 400);

	// utworzenie głównego okna programu

#ifdef WIN32

	glutCreateWindow("Sześcian 3");

#else

	glutCreateWindow("Szescian 3");

#endif

	// dołączenie funkcji generującej scenę 3D

	glutDisplayFunc(Display);

	// dołączenie funkcji wywoływanej przy zmianie rozmiaru okna

	glutReshapeFunc(Reshape);

	// dołączenie funkcji obsługi klawiatury

	glutKeyboardFunc(Klawisze);

	// dołączenie funkcji obsługi klawiszy funkcyjnych i klawiszy kursora

	// glutSpecialFunc( KlawiszeSpecjalne );

	glutSpecialFunc(KeyDown);

	glutSpecialUpFunc(KeyUp);

	// utworzenie menu podręcznego

	glutCreateMenu(Menu);

	// dodanie pozycji do menu podręcznego

	glutAddMenuEntry("Wyjście", EXIT);

	glutAddMenuEntry("Rys1", 1);

	glutAddMenuEntry("Rys2", 2);

	glutAddMenuEntry("Rys3", 3);

	// określenie przycisku myszki obsługującej menu podręczne

	glutAttachMenu(GLUT_RIGHT_BUTTON);

	GenerujListyWyswietlania();

	glutIdleFunc(Display);

	// wprowadzenie programu do obsługi pętli komunikatów

	glutMainLoop();

	return 0;

}