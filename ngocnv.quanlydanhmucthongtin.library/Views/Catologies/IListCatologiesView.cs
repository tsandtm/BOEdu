
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns;
using nvn.Library.Patterns.MVP;
//using ngocnv10052014.catology.library.Presenters;
using ngocnv10052014.catology.library.Models;

namespace ngocnv10052014.catology.library.Views
{
    public static class CreateObjectIListCatologiesView
    {
        public static void InitView(this IListCatologiesView view)
        {
            ListCatologiesPresenter presenter = new ListCatologiesPresenter(view);
        }
    }
    public interface IListCatologiesView : IPager
    {
        Guid catologyRoot { get; }

        List<Catologie> listCatologie { set; }
        int countItemSuccess { set; }
        int DropdownListIsActive { get; }

        event EventHandler<EventArgs> LoadListData_Event;
        event EventHandler<OneParameterEventAgrs<Guid>> Delete_Event;
    }
}


