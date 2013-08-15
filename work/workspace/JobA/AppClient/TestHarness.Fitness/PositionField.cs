using System;
using System.Collections.Generic;
using System.Text;
using fit;
using fitnesse;
using TestHarness.BusinessObjects;
using TaxApp.InterfacesAndConstants;
using TaxBuilder.DataObjects.EntityClasses;
using TaxBuilder.DataObjects;
using TaxBuilder.DataObjects.CollectionClasses;
using log4net;

namespace TestHarnessFitness
{
    public class PositionField : ColumnFixture
    {
        //|!-TestHarnessFitness.PositionField-!|
        //|id|X|Y|Height|Width|
        public int id;
        public int X;
        public int Y;
        public int Height;
        public int Width;
        public bool Saved()
        {
            DesignDatabaseConnectionSwitcher.SetConnectionToDesignDatabase();
            bool saved = false;
            GraphicObjectEntity goe = new GraphicObjectEntity(id);
            if (!goe.IsNew)
            {
                goe.PositionX = (short)X;
                goe.PositionY = (short)Y;
                goe.Width = (short)Width;
                goe.Height = (short)Height;
                saved = goe.Save();
            }

            DesignDatabaseConnectionSwitcher.ResetConnectionBackToMainConnectionString();
            return saved;
        }
    }
}
