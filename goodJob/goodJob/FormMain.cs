using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;

namespace goodJob
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();


            var today = DateTime.Today;

            dateTimePickerBegin.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerEnd.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month), 23, 59, 59);

        }

        private void labelPanel_Click(object sender, EventArgs e)
        {

        }

        List<DataEntities.TBEntity> DataListData = new List<DataEntities.TBEntity>();

        private void dropPanel_DragDrop(object sender, DragEventArgs e)
        {


            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);


            LoadData(filePaths);

            ProcessDataList(DataListData);
        }


        void LoadData(string[] filePaths)
        {
            DataListData.Clear();

            textBoxPaths.Clear();

            foreach (string path in filePaths)
            {
                //file就是单个文件路径

                if (!Path.GetExtension(path).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (File.Exists(path))
                {
                    textBoxPaths.Text += path + ";";



                    using (var reader = new StreamReader(path))
                    {
                        var csv = new CsvReader(reader);



                        while (csv.Read())
                        {
                            var ent = new DataEntities.TBEntity();

                            if (!(csv.FieldHeaders.Contains("标题")
                                && csv.FieldHeaders.Contains("执行者")
                                && csv.FieldHeaders.Contains("优先级")
                                && csv.FieldHeaders.Contains("开始时间")
                                && csv.FieldHeaders.Contains("截止时间")
                                && csv.FieldHeaders.Contains("创建时间")
                                && csv.FieldHeaders.Contains("完成时间")
                                && csv.FieldHeaders.Contains("创建者")

                                ))
                            {
                                break;
                            }

                            ent.Title = csv.GetField("标题");
                            ent.Info = csv.GetField("备注");
                            ent.Level = csv.GetField("优先级");
                            ent.Executor = csv.GetField("执行者");
                            if (true)
                            {
                                DateTime date;
                                if (DateTime.TryParse(csv.GetField("开始时间") ?? string.Empty, out date))
                                {
                                    ent.BeginDate = date;
                                }
                            }

                            if (true)
                            {
                                DateTime date;
                                if (DateTime.TryParse(csv.GetField("截止时间") ?? string.Empty, out date))
                                {
                                    ent.EndDate = date;
                                }
                            }

                            if (true)
                            {
                                DateTime date;
                                if (DateTime.TryParse(csv.GetField("创建时间") ?? string.Empty, out date))
                                {
                                    ent.Created = date;
                                }
                            }

                            if (true)
                            {
                                DateTime date;
                                if (DateTime.TryParse(csv.GetField("完成时间") ?? string.Empty, out date))
                                {
                                    ent.CompleteDate = date;
                                }
                            }

                            if (true)
                            {
                                int days = 0;
                                if (int.TryParse(csv.GetField("延误天数"), out days))
                                {
                                    ent.DelayDays = days;
                                }
                            }

                            ent.Creator = csv.GetField("创建者");
                            ent.Completed = csv.GetField("是否完成") == "Y";
                            ent.IsDelay = csv.GetField("已延误") == "Y";
                            ent.Tags = csv.GetField("标签");

                            if (DataListData.Exists(o => o.Title == ent.Title && o.Executor == ent.Executor))
                            {
                                continue;
                            }

                            DataListData.Add(ent);
                        }

                        reader.Close();
                    }
                }
            }

        }


        void ProcessDataList(List<DataEntities.TBEntity> datalist)
        {

            if (checkBoxType.Checked)
            {
                ProcessDataListByCreator(datalist);
            }
            else
            {
                ProcessDataListByExecutor(datalist);
            }
        }

        void ProcessDataListByCreator(List<DataEntities.TBEntity> datalist)
        {
            if (datalist == null)
            {
                return;
            }

            listView.Clear();

            listView.View = View.Details;


            ColumnHeader ch = new ColumnHeader();

            listView.Columns.Add(new ColumnHeader { Text = "任务", Width = 500 });
            listView.Columns.Add(new ColumnHeader { Text = "是否完成", Width = 100 });
            listView.Columns.Add(new ColumnHeader { Text = "执行者", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "创建者", Width = 200 });

            listView.Columns.Add(new ColumnHeader { Text = "创建时间", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "完成时间", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "标签", Width = 100 });

            listView.Columns.Add(new ColumnHeader { Text = "任务级别", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "逾期时间", Width = 200 });


            //listView.Columns.Add(new ColumnHeader { Text = "设定开始时间", Width = 200 });
            //listView.Columns.Add(new ColumnHeader { Text = "设定结束时间", Width = 200 });



            var q =
                from ent in datalist
                    //where ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && ent.Completed
                group ent by ent.Creator into g

                select new
                {
                    Name = g.Key,
                    Count = g.Count()
                };


            listView.BeginUpdate();

            listView.ShowGroups = true;

            foreach (var item in q.ToList())
            {
                var group = new ListViewGroup();
                //group.Header = item.Name;
                listView.Groups.Add(group);


                int taskCount = 0;

                var list = datalist.OrderBy(o => o.Completed).ToList().FindAll(o => o.Creator == item.Name);
                for (int i = 0; i < list.Count; i++)
                {
                    var ent = list[i];

                    //未完成
                    if (radioButtonNotComp.Checked)
                    {
                        //ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && 
                        if (!ent.Completed && ent.Created >= dateTimePickerBegin.Value && ent.Created <= dateTimePickerEnd.Value)
                        {
                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");


                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);

                            taskCount++;
                        }

                        continue;

                    }

                    //已完成
                    if (radioButtonComp.Checked)
                    {
                        if (ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && ent.Completed)
                        {
                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");
                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);

                            taskCount++;
                        }

                        continue;
                    }

                    if (radioButtonCompAll.Checked)
                    {
                        if (
                            (ent.Created >= dateTimePickerBegin.Value && ent.Created <= dateTimePickerEnd.Value)
                            || (ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value))
                        {




                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");
                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);

                            taskCount++;
                        }
                    }




                }


                group.Header = item.Name + " , Count : " + taskCount + "";

            }


            listView.EndUpdate();



        }


        void ProcessDataListByExecutor(List<DataEntities.TBEntity> datalist)
        {
            if (datalist == null)
            {
                return;
            }

            listView.Clear();

            listView.View = View.Details;


            ColumnHeader ch = new ColumnHeader();

            listView.Columns.Add(new ColumnHeader { Text = "任务", Width = 500 });
            listView.Columns.Add(new ColumnHeader { Text = "是否完成", Width = 100 });
            listView.Columns.Add(new ColumnHeader { Text = "执行者", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "创建者", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "创建时间", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "完成时间", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "标签", Width = 100 });

            listView.Columns.Add(new ColumnHeader { Text = "任务级别", Width = 200 });
            listView.Columns.Add(new ColumnHeader { Text = "逾期时间", Width = 200 });


            //listView.Columns.Add(new ColumnHeader { Text = "设定开始时间", Width = 200 });
            //listView.Columns.Add(new ColumnHeader { Text = "设定结束时间", Width = 200 });



            var q =
                from ent in datalist
                    //where ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && ent.Completed
                group ent by ent.Executor into g

                select new
                {
                    Name = g.Key,
                    Count = g.Count()
                };


            listView.BeginUpdate();

            listView.ShowGroups = true;

            foreach (var item in q.ToList())
            {






                var list = datalist.OrderBy(o => o.Completed).ToList().FindAll(o => o.Executor == item.Name);

                var group = new ListViewGroup();

                listView.Groups.Add(group);

                int taskCount = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    var ent = list[i];

                    //未完成
                    if (radioButtonNotComp.Checked)
                    {
                        //ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && 
                        if (!ent.Completed && ent.Created >= dateTimePickerBegin.Value && ent.Created <= dateTimePickerEnd.Value)
                        {
                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");


                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);

                            taskCount++;
                        }

                        continue;

                    }

                    //已完成
                    if (radioButtonComp.Checked)
                    {
                        if (ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value && ent.Completed)
                        {
                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");
                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);
                            taskCount++;
                        }

                        continue;
                    }

                    if (radioButtonCompAll.Checked)
                    {
                        if (
                            (ent.Created >= dateTimePickerBegin.Value && ent.Created <= dateTimePickerEnd.Value)
                            || (ent.CompleteDate >= dateTimePickerBegin.Value && ent.CompleteDate <= dateTimePickerEnd.Value))
                        {




                            var li = new ListViewItem(group);
                            li.Text = ent.Title;
                            //li.SubItems.Add(ent.Title);
                            li.SubItems.Add(ent.Completed ? "已完成" : "未完成");
                            li.SubItems.Add(ent.Executor);
                            li.SubItems.Add(ent.Creator);
                            li.SubItems.Add(ent.Created == null ? string.Empty : ent.Created.ToString());
                            li.SubItems.Add(ent.CompleteDate == null ? string.Empty : ent.CompleteDate.ToString());
                            li.SubItems.Add(ent.Tags);

                            li.SubItems.Add(ent.Level);
                            li.SubItems.Add(ent.DelayDays > 0 ? ent.DelayDays + "天" : "");
                            //li.SubItems.Add(ent.BeginDate == null ? string.Empty : ent.BeginDate.ToString());
                            //li.SubItems.Add(ent.EndDate == null ? string.Empty : ent.EndDate.ToString());

                            //li.Group = group;

                            //group.Items.Add(li);

                            listView.Items.Add(li);
                            taskCount++;
                        }
                    }




                }

                group.Header = item.Name + " , Count : " + taskCount + "";
            }


            listView.EndUpdate();



        }

        private void dropPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void buttonAn_Click(object sender, EventArgs e)
        {

            var files = textBoxPaths.Text.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);


            LoadData(files);

            ProcessDataList(DataListData);
        }

        private void dropPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {

            var today = DateTime.Today.AddMonths(-1);

            dateTimePickerBegin.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerEnd.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month), 23, 59, 59);

            ProcessDataList(DataListData);

        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }

        private void dateTimePickerBegin_ValueChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DataListData.Clear();
            ProcessDataList(DataListData);

        }

        private void buttonCurr_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;

            dateTimePickerBegin.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerEnd.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month), 23, 59, 59);

            ProcessDataList(DataListData);

        }


        private void radioButtonCompAll_CheckedChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }

        private void radioButtonNotComp_CheckedChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }

        private void radioButtonComp_CheckedChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }

        private void buttonEx_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            ProcessDataList(DataListData);

        }
    }
}
