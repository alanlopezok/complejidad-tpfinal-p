
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {
        private int CalcularDistancia(string str1, string str2)
        {
            // using the method
            String[] strlist1 = str1.ToLower().Split(' ');
            String[] strlist2 = str2.ToLower().Split(' ');
            int distance = 1000;
            foreach (String s1 in strlist1)
            {
                foreach (String s2 in strlist2)
                {
                    distance = Math.Min(distance, Utils.calculateLevenshteinDistance(s1, s2));
                }
            }

            return distance;
        }


        public void AgregarDato(ArbolGeneral<DatoDistancia> arbol, DatoDistancia dato)
        {
            int distancia = CalcularDistancia(dato.texto, arbol.getDatoRaiz().texto);
            if (distancia != 0)
            {
                foreach (var hijo in arbol.getHijos())
                {
                    if (distancia == hijo.getDatoRaiz().distancia)
                    {
                        AgregarDato(hijo, dato);
                        return;
                    }
                }
                dato.distancia = distancia;
                arbol.agregarHijo(new ArbolGeneral<DatoDistancia>(dato));
                return;
            }
            else
            {
                return;
            }
        }

        public void Buscar(ArbolGeneral<DatoDistancia> arbol, string elementoABuscar, int umbral, List<DatoDistancia> collected)
        {
            if (CalcularDistancia(arbol.getDatoRaiz().texto, elementoABuscar) <= umbral)
            {
                collected.Add(arbol.getDatoRaiz());
            }

            foreach (var hijo in arbol.getHijos())
            {
                Buscar(hijo, elementoABuscar, umbral, collected);
            }
        }
        public string Consulta1(ArbolGeneral<DatoDistancia> arbol)
        {
            StringBuilder result = new StringBuilder();

            if (arbol.esHoja())
            {
                result.AppendLine(arbol.getDatoRaiz().ToString().Trim());
            }
            else
            {
                foreach (var hijo in arbol.getHijos())
                {
                    result.AppendLine(Consulta1(hijo).Trim());
                }
            }

            return result.ToString();
        }
        public string Consulta2(ArbolGeneral<DatoDistancia> arbol) //corregir antes de enviar
        {
            StringBuilder result = new StringBuilder();

            Action<ArbolGeneral<DatoDistancia>, string> Consulta2Recursivo = null;
            Consulta2Recursivo = (nodo, path) =>
            {
                path += nodo.getDatoRaiz().ToString();

                if (nodo.esHoja())
                {
                    result.AppendLine(path);
                }
                else
                {
                    foreach (var hijo in nodo.getHijos())
                    {
                        Consulta2Recursivo(hijo, path + " -> ");
                    }
                }
            };

            Consulta2Recursivo(arbol, "");

            return result.ToString();
        }
        public string Consulta3(ArbolGeneral<DatoDistancia> arbol)
        {
            StringBuilder result = new StringBuilder();

            Action<ArbolGeneral<DatoDistancia>, int> Consulta3Recursivo = null;
            Consulta3Recursivo = (nodo, nivel) =>
            {
                result.AppendLine("nivel"+" "+nivel + " " + nodo.getDatoRaiz().ToString());

                foreach (var hijo in nodo.getHijos())
                {
                    Consulta3Recursivo(hijo, nivel + 1);
                }
            };

            Consulta3Recursivo(arbol, 0);

            return result.ToString();
        }
    }
}
    