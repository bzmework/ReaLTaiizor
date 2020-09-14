﻿#region Imports

using System;
using System.Windows.Forms;
using System.ComponentModel.Design;

#endregion

namespace ReaLTaiizor.Child.Metro
{
    #region MetroTabPageCollectionEditorChild

    internal class MetroTabPageCollectionEditor : CollectionEditor
    {
        public MetroTabPageCollectionEditor(Type type) : base(type)
        { }

        protected override Type[] CreateNewItemTypes()
        {
            return new[]
            {
                typeof(TabPage), typeof(MetroTabPage)
            };
        }
    }

    #endregion
}