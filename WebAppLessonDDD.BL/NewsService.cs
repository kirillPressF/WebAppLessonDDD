using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLessonDDD.Core.Models;

namespace WebAppLessonDDD.BL
{
    public class NewsService
    {
        public async Task CountView(News news)
        {
            news.CountView();
        }
    }
}
