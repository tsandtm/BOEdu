using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ngocnv10052014.catology.library.Models
{
    public class Catologie
    {
        #region Constructors
        public Catologie() { }
        public Catologie(string catologyName, Guid catologyGuid)
        {
            this.catologyName = catologyName;
            this.catologyGuid = catologyGuid;
        }
        public Catologie(string catologyName, Guid catologyGuid, int catologyID)
        {
            this.catologyName = catologyName;
            this.catologyGuid = catologyGuid;
            this.catologyID = catologyID;
        }
        #endregion

        #region Private Properties
        private Guid catologyGuid = Guid.Empty;
        private int catologyID = 0;
        private string catologyName = string.Empty;
        private string description = string.Empty;
        private Guid kindCatologyGuid = Guid.Empty;
        private string kindCatologyName = string.Empty;
        private bool isActive = false;

        private string urlHinhanh = string.Empty;
        private byte[] dataImage = null;

        private string listStringToSort = string.Empty;
        private string listPlacementName = string.Empty;
        private int levels = 0;
        private int position = 0;
        private string listPlacementGuid = string.Empty;
        #endregion

        #region Public Properties
        public string ListStringToSort
        {
            get { return listStringToSort; }
            set { listStringToSort = value; }
        }

        public string ListPlacementGuid
        {
            get { return listPlacementGuid; }
            set { listPlacementGuid = value; }
        }

        public string ListPlacementName
        {
            get { return listPlacementName; }
            set { listPlacementName = value; }
        }

        public int Levels
        {
            get { return levels; }
            set { levels = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        public byte[] DataImage
        {
            get { return dataImage; }
            set { dataImage = value; }
        }

        public string UrlHinhanh
        {
            get { return urlHinhanh; }
            set { urlHinhanh = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public Guid CatologyGuid
        {
            get { return catologyGuid; }
            set { catologyGuid = value; }
        }
        public int CatologyID
        {
            get { return catologyID; }
            set { catologyID = value; }
        }
        public string CatologyName
        {
            get { return catologyName; }
            set { catologyName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Guid KindCatologyGuid
        {
            get { return kindCatologyGuid; }
            set { kindCatologyGuid = value; }
        }
        public string KindCatologyName
        {
            get { return kindCatologyName; }
            set { kindCatologyName = value; }
        }
        #endregion
    }
}

