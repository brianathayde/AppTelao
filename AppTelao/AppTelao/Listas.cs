using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTelao
{
    class Listas
    {
        static List<string> userTweets = new List<string>();

        // chegar no maximo os tweets forerem diferenters zerar
        public static int contador;

        // 0...4
        public const int maxTweets = 4;


        public static bool NovoTweet(string tweet)
        {            
            bool diferente = true;

            for (int i = 0; i< userTweets.Count; i++)
            {
                if (tweet == userTweets[i])
                {
                    diferente = false;
                }
            }
            if (diferente == true)
            {
                contador++;

                if (contador > maxTweets)
                {
                    contador = 0;
                }

                //se lista cheia
                if (userTweets.Count > maxTweets)
                {
                    userTweets.RemoveAt(contador);
                }
                userTweets.Add(tweet);
            }

            return diferente;
        }
    }
}
