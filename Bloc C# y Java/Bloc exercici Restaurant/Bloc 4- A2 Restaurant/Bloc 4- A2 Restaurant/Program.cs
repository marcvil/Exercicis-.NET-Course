using System;
using System.Collections.Generic;

namespace Bloc_4__A2_Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            int billete5Valor = 5, billete10Valor = 10, billete20Valor = 20, billete50Valor = 50, billete100Valor = 100, billete200Valor = 200, billete500Valor = 500;
            int numbillete5 = 0, numbillete10 = 0, numbillete20 = 0, numbillete50 = 0, numbillete100 = 0, numbillete200 = 0, numbillete500 = 0;
            int precioTotal = 0;

            string[] listaMenu = new string[5];
            int[] listaPrecios = new int[5];

            List<string> listaCliente = new List<string>();


            Console.WriteLine("Buenos días! Introduce los platos que hay en el menú y su precio");

            RellenarListaMenu(listaMenu, listaPrecios);
            MostrarMenu(listaMenu, listaPrecios);
            PedirListaCliente(listaMenu, listaCliente);
            ConfirmarPedido(listaMenu, listaCliente);
            precioTotal = MostrarPrecio(precioTotal, listaMenu, listaPrecios, listaCliente);
            Console.WriteLine("ELPRECIO TOTAL ES DE" + precioTotal);
            GestionarBilletes(billete5Valor, billete10Valor, billete20Valor, billete50Valor, billete100Valor, billete200Valor, billete500Valor, ref numbillete5, numbillete10, ref numbillete20, ref numbillete50, ref numbillete100, ref numbillete200, ref numbillete500,  precioTotal);
        }

        private static void GestionarBilletes(int billete5Valor, int billete10Valor, int billete20Valor, int billete50Valor, int billete100Valor, int billete200Valor, int billete500Valor, ref int numbillete5, int numbillete10, ref int numbillete20, ref int numbillete50, ref int numbillete100, ref int numbillete200, ref int numbillete500, int precioTotal)
        {

            Console.WriteLine("Puedes pagar con los siguientes billetes: ");
            Console.WriteLine(precioTotal);
            while (precioTotal >= 5)
            {
                if (precioTotal / billete500Valor >= 1 && precioTotal>= 500)
                {
                    numbillete500++;
                    precioTotal -= billete500Valor;
                    continue;
                }
                else if (precioTotal / billete200Valor >= 1 && precioTotal >= 200)
                {
                    numbillete200++;
                    precioTotal -= billete200Valor;
                    continue;
                }
                else if(precioTotal / billete100Valor >= 1 && precioTotal >= 100)
                {
                    numbillete100++;
                    precioTotal -= billete100Valor;
                    continue;
                }
                else if(precioTotal / billete50Valor >= 1 && precioTotal >= 50)
                {
                    numbillete50++;
                    precioTotal -= billete50Valor;
                    continue;
                }
                else if(precioTotal / billete20Valor >= 1 && precioTotal >= 20)
                {
                    numbillete20++;
                    precioTotal -= billete20Valor;
                    continue;
                }
                else if(precioTotal / billete10Valor >= 1 && precioTotal >= 10)
                {
                    numbillete500++;
                    precioTotal -= billete10Valor;
                    continue;
                }
                else if (precioTotal / billete5Valor >= 1 && precioTotal >= 5)
                {
                    numbillete5++;
                    precioTotal -= billete5Valor;
                    continue;
                }

            }
            Console.WriteLine("Los billetes que necessitas son:  \n" +
                                " Billetes de 500:" + numbillete500 + "\n" +
                                " Billetes de 200:" + numbillete200 + "\n" +
                                " Billetes de 100:" + numbillete100 + "\n" +
                                " Billetes de 50:" + numbillete50 + "\n" +
                                " Billetes de 20:" + numbillete20 + "\n" +
                                " Billetes de 10:" + numbillete10 + "\n" +
                                " Billetes de 5:" + numbillete5 + "\n" +
                                " Faltarán: " + precioTotal + "€ en monedas."
                                );
        }

        private static int MostrarPrecio(int precioTotal, string[] listaMenu, int[] listaPrecios, List<string> listaCliente)
        {
            foreach (string c in listaCliente)
            {
                for (int i = 0; i < listaMenu.Length; i++)
                {
                    if (c == listaMenu[i])
                    {
                        precioTotal += listaPrecios[i];
                    }
                    
                }
            }
            
            Console.WriteLine("El precio total es de: " + precioTotal);
            return precioTotal;
            
        }

        private static void ConfirmarPedido(string[] listaMenu, List<string> listaCliente)
        {
            Console.WriteLine("Es este tu pedido final?:");
            int opcionconfirmacion = 0;
            for (int i = 0; i < listaCliente.Count; i++)
            {
                Console.WriteLine(listaCliente[i]);

            }
            Console.WriteLine("Si es correcto, pulsa 1. En caso contrario, pulsa 0.");
            opcionconfirmacion = EntradaNúmeroPorConsola();
            if (opcionconfirmacion == 1)
            {
                return;
            }
            else if (opcionconfirmacion == 0)
            {
                PedirListaCliente(listaMenu, listaCliente);
            }
            else
            {
                Console.WriteLine("Número no válido.");
                //Volver a pedir confirmación
                ConfirmarPedido(listaMenu, listaCliente);

            }
        }

        static int  EntradaNúmeroPorConsola()
        {
            int input = Int32.Parse(Console.ReadLine());
            return input;
        }
        private static void PedirListaCliente(string[] listaMenu, List<string> listaCliente)
        {
            Console.WriteLine("Elige los platos del menú que quieras introduciendo el número de la lista: ");
            int clausulaloop = 1;
            while (clausulaloop == 1)
            {
                Console.WriteLine("Plato número " + (listaCliente.Count +1) +": ");
                int opcion;
                opcion = EntradaNúmeroPorConsola();
                listaCliente.Add(listaMenu[opcion - 1]);
                Console.WriteLine("¿Tienes más hambre? Si quieres pedir más pulsa 1. En caso contrario, pulsa 0. ");
                clausulaloop = EntradaNúmeroPorConsola();
            }
        }

        private static void MostrarMenu(string[] listaMenu, int[] listaPrecios)
        {
            Console.WriteLine("En el menú de hoy tenemos los siguientes platos: ");
            for (int j = 0; j < listaMenu.Length; j++)
            {
                Console.WriteLine((j+1) + ". " + listaMenu[j] + " con el precio: " + listaPrecios[j]);

            }
        }

        private static void RellenarListaMenu(string[] listaMenu, int[] listaPrecios)
        {
            for (int i = 0; i < listaMenu.Length; i++)
            {
                Console.WriteLine("Introduce el nombre del plato " + (i+1));
                string temp = Console.ReadLine();

                listaMenu[i] = temp;

                Console.WriteLine("Introduce el precio del plato:  " + listaMenu[i]);
                string temp2 = Console.ReadLine();
                listaPrecios[i] = Int32.Parse(temp2);

            }
        }


    }
}
