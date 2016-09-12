using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        private Partida juego;
        public Inicio()
        {
            InitializeComponent();
            // Crear la partida Circulo para la persona, cruz para la maquina
            juego = new Partida(Figuras.Circulo, Figuras.Cruz);
            juego.Iniciar();            
        }
        /// <summary>
        /// Evento para el click izquierdo sobre un canvas
        /// </summary>
        /// <param name="sender">canvas origen</param>
        /// <param name="e"> Parametros del evento</param>
        private void CanvasPulsado(object sender, MouseButtonEventArgs e)
        {
            // Convertir el objecto sender a canvas
            Canvas can = (sender as Canvas);
            string casillaDondeSeJuega = juego.HacerJugada(can.Name);
            // Revisar si es válido el juego.
            if (casillaDondeSeJuega != "")
            {
                Dibujar(can, juego.FiguraADibujar());
            }
            // Pedir jugada de la maquina
            casillaDondeSeJuega = juego.HacerJugada();
            // Revisar si la jugada de la maquina es valida
            if (casillaDondeSeJuega != "")
            {
                can = (this.FindName(casillaDondeSeJuega) as Canvas);
                Dibujar(can, juego.FiguraADibujar());
            }
            // Alguien gano?
            if (juego.Ganador != null)
            {
                MessageBox.Show("El ganador es:" + juego.Ganador.ToString());
            }

        }
        /// <summary>
        /// Metodo para Dibujar sobre el canvas que recibio el click
        /// </summary>
        /// <param name="objeto">Canvas origen</param>
        /// <param name="jugada">Figura a dibujar</param>
        private void Dibujar(Canvas objeto, Figuras jugada)
        {

            if (jugada == Figuras.Circulo)
            {
                Ellipse el = new Ellipse();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();

                // Describes the brush's color using RGB values. 
                // Each value has a range of 0-255.
                mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
                el.Fill = mySolidColorBrush;
                el.Width = objeto.ActualWidth;
                el.Height = objeto.ActualHeight;

                objeto.Children.Add(el);
            }
            else
            {
                // Si es Cruz
                Line linea1 = new Line();
                linea1.Stroke = SystemColors.WindowFrameBrush;
                linea1.StrokeThickness = 4;
                linea1.X1 = 0;
                linea1.Y1 = 0;
                linea1.X2 = objeto.ActualWidth;
                linea1.Y2 = objeto.ActualHeight;
                Line linea2 = new Line();
                linea2.Stroke = SystemColors.WindowFrameBrush;
                linea2.StrokeThickness = 4;
                linea2.X1 = objeto.ActualWidth;
                linea2.Y1 = 0;
                linea2.X2 = 0;
                linea2.Y2 = objeto.ActualHeight;
                objeto.Children.Add(linea1);
                objeto.Children.Add(linea2);
            }
            // Quitar el evento al canvas pulsado
            objeto.MouseLeftButtonDown -= CanvasPulsado;
        }
        /// <summary>
        /// Metodo para limpiar la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reiniciar_Click(object sender, RoutedEventArgs e)
        {
            // Limpiar los canvas de los dibujos
            c0.Children.Clear();
            c1.Children.Clear();
            c2.Children.Clear();
            c3.Children.Clear();
            c4.Children.Clear();
            c5.Children.Clear();
            c6.Children.Clear();
            c7.Children.Clear();
            c8.Children.Clear();
            // Remover y agregar el listener a cada canvas
            RemoverYAgregarListener(c0);
            RemoverYAgregarListener(c1);
            RemoverYAgregarListener(c2);
            RemoverYAgregarListener(c3);
            RemoverYAgregarListener(c4);
            RemoverYAgregarListener(c5);
            RemoverYAgregarListener(c6);
            RemoverYAgregarListener(c7);
            RemoverYAgregarListener(c8);
            // Reiniciar la cuenta de jugadas y estado de la partida
            juego.Iniciar();
        }/// <summary>
        /// Metodo para asegurar que se reinicio el listener de un canvas
        /// </summary>
        /// <param name="canvas"></param>
        private void RemoverYAgregarListener(Canvas canvas)
        {
            canvas.MouseLeftButtonDown -= CanvasPulsado;
            canvas.MouseLeftButtonDown += CanvasPulsado;
        }
    }
}
