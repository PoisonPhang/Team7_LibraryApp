using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Team7_LibraryApp
{
    public static class ExtentionMethods
    {

        /// <summary>
        /// Find the first ancestor in the Visual Tree that has the specified type,
        /// or null if no ancestor is found
        /// </summary>
        /// <typeparam name="T">The type to search for</typeparam>
        /// <param name="obj">The first ancestor of type T, or null</param>
        /// <returns></returns>
        public static T FindAncestor<T>(this DependencyObject obj) where T : DependencyObject
        {

            var parent = VisualTreeHelper.GetParent(obj);

            if (parent == null) return null;

            if (parent is T) return parent as T;

            return FindAncestor<T>(parent);

        }

    }
}
