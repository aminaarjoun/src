using System;
using System.Collections.Generic;
using System.Text;
using jp_live_search.MSNSearch;
using System.Diagnostics;
namespace jp_live_search
{
    class Buscador
    {
         string query;
        int resultadosPorPag;
        string queryAnterior;
        Result[] res = null;
        public Buscador() {
            Console.WriteLine("--------------------");
            Console.WriteLine("|  JP Live Search  |");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            bool continuar = true;
            int cantMore = 0;
            resultadosPorPag = Properties.Settings.Default.ResultadosPorPagina;
            while (continuar)
            {
                pedirQuery();
                if (query != "x")
                {

                        if ((res != null) && (esNumero(query)))
                        {
                            #region "abrir resultado"
                            try
                            {
                                
                                int indice = Int32.Parse(query);
                                if (indice > 0) {
                                    indice = indice % resultadosPorPag;
                                    if (indice == 0)
                                    {
                                        indice = resultadosPorPag;
                                    }

                                    if (esValorValido(indice))
                                    {
                                        Process.Start(res[indice - 1].Url);
                                    }
                                }
                                
                            }
                            catch (System.ComponentModel.Win32Exception ex)
                            {
                            }
                            #endregion
                        }
                        else
                        {
                            if (query == "+" && res != null)
                            {
                                cantMore++;
                                query = queryAnterior;
                            }
                            else
                            {
                                cantMore = 0;
                            }
                            
                            int cant=RealizarBusqueda(query, cantMore * resultadosPorPag);
                            queryAnterior = query;
                            ImprimirResultados(cant, res, cantMore * resultadosPorPag);
                        }
                }
                else {
                    continuar = false;
                }
                    
            }

        }
        private bool esValorValido(int valor) {
            return valor > 0 && valor <= resultadosPorPag;
        }
        private static void ImprimirResultados(int cant,Result[] res,int offset)
        {
            Console.WriteLine();
            Console.WriteLine("{0} resultados", String.Format("{0:### ### ### ### ###}", cant));
            Console.WriteLine();
            
            for (int i=0; i < res.Length; i++)
            {
                Console.WriteLine((offset+i+1).ToString() + ". " + res[i].Title);
            }
            Console.WriteLine();
        }
        private bool esNumero(string str) {
            bool ret = true;
            for (int i = 0; i < str.Length; i++) { 
                if(!Char.IsNumber(str[i])){
                    ret = false;
                }
            }
            return ret;
        }
        private void pedirQuery()
        {
            Console.WriteLine();
            Console.Write("Buscar: ");
            query= Console.ReadLine();
            
        }

        private int RealizarBusqueda(string query,int offset)
        {
            //MSNSearchPortTypeClient s = new MSNSearchPortTypeClient();
            MSNSearch.MSNSearchService s = new MSNSearchService();
            SearchRequest searchRequest = new SearchRequest();
            int arraySize = 1;
            SourceRequest[] sr = new SourceRequest[arraySize];

            sr[0] = new SourceRequest();
            sr[0].Source = SourceType.Web;
            sr[0].Count = resultadosPorPag;
            sr[0].Offset = offset;

            searchRequest.Query = query;
            searchRequest.Requests = sr;
            // Enter the Application ID, in double quotation marks, supplied by the 
            // Developer Provisioning System, as the value of the AppID on the SearchRequest.
            searchRequest.AppID = "00E563DCB26A22584ADD1A1F2F182FC8E184B25A";
            searchRequest.CultureInfo = "en-US";
            SearchResponse searchResponse;
            searchResponse = s.Search(searchRequest);
            res = searchResponse.Responses[0].Results;

            return searchResponse.Responses[0].Total;
        }
    }
    }

