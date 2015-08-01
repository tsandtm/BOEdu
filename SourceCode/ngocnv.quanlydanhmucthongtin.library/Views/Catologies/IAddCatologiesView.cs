
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns;
using nvn.Library.Patterns.MVP;
using ngocnv10052014.catology.library.Presenters;
using ngocnv10052014.catology.library.Models;

namespace ngocnv10052014.catology.library.Views
{
    public static class CreateObjectIAddCatologiesView
    {
        public static void InitView(this IAddCatologiesView view)
        {
            AddCatologiesPresenter presenter = new AddCatologiesPresenter(view);
        }
    }
    public interface IAddCatologiesView : IBaseView
    {
        Guid guidRootCatology { get; }

        Catologie itemCatologie { set; }
        List<Catologie> listCatologies { set; }

        event EventHandler<TowParameterEventAgrs<string,Guid>> LoadData_Event;
        event EventHandler<OneParameterEventAgrs<Catologie>> Save_Event;

        event EventHandler<OneParameterEventAgrs<Catologie>> SaveFile_Event;


        string UrlServer { get; }
        string[] ListUrl { get; }
        int[] ListHight { get; }
        int[] ListWith { get; }
        int[] ListQuality { get; }
    }
}


