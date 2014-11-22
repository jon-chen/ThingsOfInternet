using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;
using Xamarin.Forms.Labs;

namespace ThingsOfInternet.Controls
{
    public class BindableGrid : Grid
    {
        public static readonly BindableProperty ColumnsProperty = BindableProperty.Create<BindableGrid, int>(x => x.Columns, 1);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create<BindableGrid, IEnumerable>(x => x.ItemsSource, null, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create<BindableGrid, DataTemplate>(x => x.ItemTemplate, null);

        protected IEnumerable items;
        protected int rowIndex;
        protected int colIndex;
        protected int rowHeight;

        public int Columns
        {
            get { return (int)base.GetValue(ColumnsProperty); }
            set { base.SetValue(ColumnsProperty, value); }
        }

        public IEnumerable ItemsSource 
        { 
            get { return (IEnumerable)base.GetValue(ItemsSourceProperty); } 
            set { base.SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)base.GetValue(ItemTemplateProperty); }
            set { base.SetValue(ItemTemplateProperty, value); }
        }

        public BindableGrid()
        {

        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            var display = ServiceLocator.Current.GetInstance<IDisplay>();
            this.rowHeight = (Columns > 1) ? (int)display.Xdpi / Columns : 120;

            ColumnDefinitions = new ColumnDefinitionCollection();
            for (int i = 0; i < Columns; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            RowDefinitions = new RowDefinitionCollection();
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(rowHeight, GridUnitType.Absolute) });
        }

        protected void UpdateGrid(IEnumerable items, bool isAdd)
        {
            if (isAdd)
            {
                foreach (var item in items)
                {
                    if (colIndex == ColumnDefinitions.Count)
                    {
                        colIndex = 0;
                        rowIndex++;

                        RowDefinitions.Add(new RowDefinition { Height = new GridLength(rowHeight) });
                    }

                    View child;
                    if (ItemTemplate != null)
                    {
                        child = ItemTemplate.CreateContent() as View;
                        child.BindingContext = item;
                    }
                    else
                    {
                        child = new Label { Text = item.ToString() };
                    }

                    this.Children.Add(child, colIndex, rowIndex);

                    colIndex++;
                }
            }
        }

        private static void OnItemsSourceChanged(BindableObject obj, IEnumerable oldValue, IEnumerable newValue)
        {
            var grid = obj as BindableGrid;

            if (oldValue != null)
            {
                var coll = (INotifyCollectionChanged)oldValue;
                coll.CollectionChanged -= grid.OnItemsSourceCollectionChanged;
            }

            if (newValue != null)
            {
                var coll = (INotifyCollectionChanged)newValue;
                coll.CollectionChanged += grid.OnItemsSourceCollectionChanged;
                grid.UpdateGrid(newValue, true);
            }
        }

        private void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // TODO: Do something clever here to update the grid.
//            if (e.Action == NotifyCollectionChangedAction.Reset)
//            {
//                // Clear and update entire collection
//            }
//
//            if (e.NewItems != null)
//            {
//
//            }
//
//            if (e.OldItems != null)
//            {
//
//            }
//
//            UpdateGrid();
        }
    }
}

