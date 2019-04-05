using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace GUI_DFM
{
    public partial class MainWindow
    {
        private Point _dragStartPoint;
        public IList<Vertex> routeListElements = new ObservableCollection<Vertex>();
        
        private T FindVisualParent<T>(DependencyObject child) where T : class
        {
            var parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
            {
                return null;
            }
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            return FindVisualParent<T>(parentObject);
        }

        private void route_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(null);
            Vector diff = _dragStartPoint - point;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                var lb = sender as ListBox;
                var lbi = FindVisualParent<ListBoxItem>(((DependencyObject)e.OriginalSource));
                if (lbi != null)
                {
                    DragDrop.DoDragDrop(lbi, lbi.DataContext, DragDropEffects.Move);
                }
            }
        }

        private void routeItem_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBoxItem)
            {
                var source = e.Data.GetData(typeof(Vertex)) as Vertex;
                var target = ((ListBoxItem)(sender)).DataContext as Vertex;

                int sourceIndex = lstRoute.Items.IndexOf(source);
                int targetIndex = lstRoute.Items.IndexOf(target);

                Move(source, sourceIndex, targetIndex);
            }
        }

        private void routeItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragStartPoint = e.GetPosition(null);
        }

        private void Move(Vertex source, int sourceIndex, int targetIndex)
        {
            if (sourceIndex < targetIndex)
            {
                routeListElements.Insert(targetIndex + 1, source);
                routeListElements.RemoveAt(sourceIndex);
            }
            else
            {
                int removeIndex = sourceIndex + 1;
                if (routeListElements.Count + 1 > removeIndex)
                {
                    routeListElements.Insert(targetIndex, source);
                    routeListElements.RemoveAt(removeIndex);
                }
            }
        }
    }
}
