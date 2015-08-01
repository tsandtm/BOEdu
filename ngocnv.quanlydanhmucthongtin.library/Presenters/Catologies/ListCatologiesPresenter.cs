

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nvn.Library.Patterns.MVP;
using nvn.Library.Patterns;
using ngocnv10052014.catology.library.Views;
using ngocnv10052014.catology.library.Models;
using project.config.library.Utilities;

namespace ngocnv10052014.catology.library.Presenters
{
    public class ListCatologiesPresenter : BasePresenter<IListCatologiesView>
    {
        public ListCatologiesPresenter(IListCatologiesView view)
            : base(view)
        {
            view.FristLoadEventHandler += new EventHandler<EventArgs>(view_FristLoadEventHandler);
            view.Delete_Event += new EventHandler<OneParameterEventAgrs<Guid>>(view_Delete_Event);
            view.LoadListData_Event += new EventHandler<EventArgs>(view_LoadListData_Event);
        }

        #region All event
        void view_LoadListData_Event(object sender, EventArgs e)
        {
            BindingData(view.catologyRoot, view.DropdownListIsActive);
        }

        void view_FristLoadEventHandler(object sender, EventArgs e)
        {
            view.PapeNumbers = ConstantVariable.PaperNumbers();
            BindingData(view.catologyRoot, view.DropdownListIsActive);
        }

        //---------------------------->Xoa du lieu<---------------------------//
        void view_Delete_Event(object sender, OneParameterEventAgrs<Guid> e)
        {
            ICatologieBAL itemBAL = new CatologieBAL();
            itemBAL.Delete(e.myType);
        }
        //---------------------------->End Xoa du lieu<---------------------------//

        #endregion

        #region private method

        private void BindingData(Guid RootGuid,int IsActive)
        {
            int totalPages = 1;
            ICatologieBAL itemBAL = new CatologieBAL();
             List<Catologie> ListCatologie = itemBAL.GetPage(
                view.catologyRoot,
                view.DropdownListIsActive,
                view.PageNumber,
                view.PageSize,
                out totalPages);
            view.TotalPages = totalPages;
            view.listCatologie = ListCatologie;
        }
        #endregion
    }
}



