﻿using System;
using System.Windows;
using DlhSoft.Windows.Controls;

namespace Demos.WPF.CSharp.ScheduleChartDataGrid.CustomAppearance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GanttChartItem task1 = ScheduleChartDataGrid.Items[0].GanttChartItems[0];
            task1.Start = DateTime.Today.Add(TimeSpan.Parse("08:00:00"));
            task1.Finish = DateTime.Today.Add(TimeSpan.Parse("16:00:00"));
            task1.CompletedFinish = DateTime.Today.Add(TimeSpan.Parse("12:00:00"));

            GanttChartItem task21 = ScheduleChartDataGrid.Items[0].GanttChartItems[1];
            task21.Start = DateTime.Today.AddDays(1).Add(TimeSpan.Parse("12:00:00"));
            task21.Finish = DateTime.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"));
            task21.AssignmentsContent = "50%";

            GanttChartItem task22 = ScheduleChartDataGrid.Items[1].GanttChartItems[0];
            task22.Start = DateTime.Today.AddDays(1).Add(TimeSpan.Parse("12:00:00"));
            task22.Finish = DateTime.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"));

            for (int i = 3; i <= 16; i++)
            {
                ScheduleChartItem item = new ScheduleChartItem { Content = "Resource " + i };
                for (int j = 1; j <= (i - 1) % 4 + 1; j++)
                {
                    item.GanttChartItems.Add(
                        new GanttChartItem
                        {
                            Content = "Task " + i + "." + j,
                            Start = DateTime.Today.AddDays(i + (i - 1) * (j - 1)),
                            Finish = DateTime.Today.AddDays(i * 1.2 + (i - 1) * (j - 1) + 1),
                            CompletedFinish = DateTime.Today.AddDays(i + (i - 1) * (j - 1)).AddDays((i + j) % 5 == 2 ? 2 : 0)
                        });
                }
                ScheduleChartDataGrid.Items.Add(item);
            }
        }

        private string theme = "Generic-bright";
        public MainWindow(string theme) : this()
        {
            this.theme = theme;
            ApplyTemplate();
        }
        public override void OnApplyTemplate()
        {
            LoadTheme();
            base.OnApplyTemplate();
        }
        private void LoadTheme()
        {
            if (theme == null || theme == "Default" || theme == "Aero")
                return;
            var themeResourceDictionary = new ResourceDictionary { Source = new Uri("/" + GetType().Assembly.GetName().Name + ";component/Themes/" + theme + ".xaml", UriKind.Relative) };
            ScheduleChartDataGrid.Resources.MergedDictionaries.Add(themeResourceDictionary);
        }
    }
}
