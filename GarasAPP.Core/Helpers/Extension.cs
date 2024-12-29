using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Helpers
{
    public static class Extension
    {

        public static string SearchedKey(string Keyword)
        {

            string SearchedKey = "%";

            foreach (var c in Keyword)
            {
                switch (c)
                {
                    case 'أ':
                    case 'ا':
                    case 'إ':
                    case 'ء':
                        SearchedKey += "[ءاأإآ]";
                        break;

                    case 'ه':
                    case 'ة':
                        SearchedKey += "[ه|ة]";
                        break;

                    case 'ي':
                    case 'ى':
                    case 'ئ':
                        SearchedKey += "[ى|ي|ئ]";
                        break;

                    case ' ':
                        SearchedKey += "%%";
                        break;

                    case 'و':
                    case 'ؤ':
                        SearchedKey += "[و|ؤ]";
                        break;

                    default:
                        SearchedKey += c;
                        break;
                }
            }
            SearchedKey += "%";

            return SearchedKey;

        }
        

    }
}
