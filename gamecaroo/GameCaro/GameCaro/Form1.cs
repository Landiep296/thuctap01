using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();

            ChessBoard = new ChessBoardManager(pnlChessBoard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;// gắn evern lại engame 
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked; //gắn lị event để có playeermảrk 

            prcbCoolDown.Step = Cons.COOl_DOwn_STEP; //xét thuộc tính  thời gian chạy 
            prcbCoolDown.Maximum = Cons.COOl_DOwn_TIME;//xét thuộc tính tối đa thời gian 
            prcbCoolDown.Value = 0;//gắn giá trị ban đầu bằng 0 

            tmCoolDown.Interval = Cons.COOl_DOwn_INTERVAL;// gắn tmcooldown bằng prcb tăng lên dần 

            NewGame();
        }
        #region Methods //gom code 
        void EndGame()//tạo hàm endgame đẻ sửa dụng chung cho and game và playmark 
        {
            tmCoolDown.Stop();//kết tthusc thời gian chạy trong prcb 
            pnlChessBoard.Enabled = false;//win game không click được nữa 
            MessageBox.Show("Bạn Đã Thắng ");
        }



        void NewGame()
        {
            prcbCoolDown.Value = 0;//reset bằng 0 
            tmCoolDown.Stop();//dừng 
            ChessBoard.DrawChessBoard();
            
        }


        void Quit()
        {
            Application.Exit(); //hàm nhấn vào thoát game 
        }

        void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();//nhấn vào nuót thì bắt đầu thời gian 
            prcbCoolDown.Value = 0;//reset lbắt đầu bằng 0 
        }

        void ChessBoard_EndedGame(object sender, EventArgs e) 
        {
            EndGame();// thông báo win 
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();//làm prcb chạy 

            if (prcbCoolDown.Value >= prcbCoolDown.Maximum) // nếu như value lớn hơn maiximum thì kết thúc game 
            {
                EndGame();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát game ", "thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)  //gọi hàm lỡ bấm nhầm thoát game nếu không phải ok không thoát game
            e.Cancel = true;//nhán và cancel không thoát được 
        }

        #endregion //gom code 
    }
}
