using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_DIYTools
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadMapDoc2();
        }
        /// <summary>
        /// 运用MapDocument对象中的Open方法的函数加载mxd文档
        /// </summary>
        private void loadMapDoc2()
        {
            IMapDocument mapDocument = new MapDocumentClass();
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "打开地图文档";
                ofd.Filter = "map documents(*.mxd)|*.mxd";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string pFileName = ofd.FileName;
                    //filePath——地图文档的路径, ""——赋予默认密码
                    mapDocument.Open(pFileName, "");
                    for (int i = 0; i < mapDocument.MapCount; i++)
                    {
                        //通过get_Map(i)方法逐个加载
                        axMapControl1.Map = mapDocument.get_Map(i);
                    }
                    axMapControl1.Refresh();
                }
                else
                {
                    mapDocument = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        /// <summary>
        /// 放大工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomIntoolStripButton1_Click(object sender, EventArgs e)
        {
            //当选中为数据制图时
            if (tabControl1.SelectedIndex == 0)
            {
                //ICommand提供对定义COM命令的成员的访问。
                ICommand pCommand = new ControlsMapZoomInToolClass();
                //将ICommand强转成ITool
                ITool pTool = pCommand as ITool;
                //调用ICommand中的OnCreate方法生成放大工具
                pCommand.OnCreate(this.axMapControl1.Object);
                //设置放大工具命令的作用对象为axMapControl1
                this.axMapControl1.CurrentTool = pTool;
            }
            //当选中为布局视图时
            if (tabControl1.SelectedIndex == 1)
            {
                //ICommand提供对定义COM命令的成员的访问。
                ICommand pCommand = new ControlsMapZoomInToolClass();
                //将ICommand强转成ITool
                ITool pTool = pCommand as ITool;
                //调用ICommand中的OnCreate方法生成放大工具
                pCommand.OnCreate(this.axPageLayoutControl1.Object);
                //设置放大工具命令的作用对象为axPageLayoutControl1
                this.axPageLayoutControl1.CurrentTool = pTool;
            }

        }
        /// <summary>
        /// 缩小工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomOuttoolStripButton2_Click(object sender, EventArgs e)
        {
            //当选中为数据视图时
            if (tabControl1.SelectedIndex == 0)
            {
                ICommand pCommand = new ControlsMapZoomOutToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axMapControl1.Object);
                this.axMapControl1.CurrentTool = pTool;
            }
            //当选中为布局视图时
            if (tabControl1.SelectedIndex == 1)
            {
                ICommand pCommand = new ControlsMapZoomOutToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axPageLayoutControl1.Object);
                this.axPageLayoutControl1.CurrentTool = pTool;
            }
        }

        /// <summary>
        /// 漫游工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PantooltoolStripButton4_Click(object sender, EventArgs e)
        {
            //当选中为数据视图时
            if (tabControl1.SelectedIndex == 0)
            {
                ICommand pCommand = new ControlsMapPanToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axMapControl1.Object);
                this.axPageLayoutControl1.CurrentTool = pTool;
            }
            //当选中为布局视图时
            if (tabControl1.SelectedIndex == 1)
            {
                ICommand pCommand = new ControlsMapPanToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axPageLayoutControl1.Object);
                this.axPageLayoutControl1.CurrentTool = pTool;
            }
        }

        /// <summary>
        /// 全图工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomFulltoolStripButton3_Click(object sender, EventArgs e)
        {
            //当选中为数据视图时
            if (tabControl1.SelectedIndex == 0)
            {
                ICommand pCommand = new ControlsMapFullExtentCommandClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axMapControl1.Object);
                this.axMapControl1.CurrentTool = pTool;
                pCommand.OnClick();
            }
            //当选中为布局视图时
            if (tabControl1.SelectedIndex == 1)
            {
                ICommand pCommand = new ControlsMapFullExtentCommandClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axPageLayoutControl1.Object);
                this.axPageLayoutControl1.CurrentTool = pTool;
                pCommand.OnClick();
            }
        }
        /// <summary>
        /// 指针选择工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelecttoolStripButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ICommand pCommand = new ControlsSelectFeaturesToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axMapControl1.Object);
                this.axMapControl1.CurrentTool = pTool;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                ICommand pCommand = new ControlsSelectFeaturesToolClass();
                ITool pTool = pCommand as ITool;
                pCommand.OnCreate(this.axPageLayoutControl1.Object);
                this.axPageLayoutControl1.CurrentTool = pTool;
            }
        }
    }
}
