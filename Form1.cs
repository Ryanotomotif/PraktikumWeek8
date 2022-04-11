using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumWeek8
{
	public partial class FormHasilPertandingan : Form
	{
		public FormHasilPertandingan()
		{
			InitializeComponent();
		}

		public static string sqlConnection = "server=localhost;uid=root;pwd=;database=premier_league";
		public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
		public MySqlCommand sqlCommand; 
		public MySqlDataAdapter sqlAdapter;
		public string sqlQuery;

		private void FormHasilPertandingan_Load(object sender, EventArgs e)
		{
			DataTable dtTeamHome = new DataTable();
			sqlQuery = "SELECT team.team_name as 'Nama Tim' ,team.manager_id as 'ID Manager', manager.manager_name as 'Nama Manager', team.home_stadium, team.capacity, team.team_id FROM team, manager";
			sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
			sqlAdapter = new MySqlDataAdapter(sqlCommand);
			sqlAdapter.Fill(dtTeamHome);
			cBoxTeamHome.DataSource = dtTeamHome;
			cBoxTeamHome.DisplayMember = "Nama Tim";
			cBoxTeamHome.ValueMember = "ID Manager";


			DataTable dtTeamAway = new DataTable();
			sqlQuery = "SELECT team.team_name as 'Nama Tim' ,team.manager_id as 'ID Manager', manager.manager_name as 'Nama Manager', team.home_stadium, team.capacity, team.team_id FROM team, manager";
			sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
			sqlAdapter = new MySqlDataAdapter(sqlCommand);
			sqlAdapter.Fill(dtTeamAway);
			cBoxTeamAway.DataSource = dtTeamAway;
			cBoxTeamAway.DisplayMember = "Nama Tim";
			cBoxTeamAway.ValueMember = "ID Manager";
		}

		private void cBoxTeamHome_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			try
			{
				DataTable dtManagerHome = new DataTable();
				sqlQuery = "SELECT manager.manager_id, manager.manager_name, team.team_id FROM manager,team WHERE manager.manager_id = '" + cBoxTeamHome.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtManagerHome);
				lblManagerHome.Text = dtManagerHome.Rows[0][1].ToString();
			}
			catch (Exception)
			{

				
			}
			try
			{
				DataTable dtCaptainHome = new DataTable();
				sqlQuery = "SELECT player.player_id, player.player_name, team.team_id, team.captain_id FROM player,team WHERE player.player_id = '" + cBoxTeamHome.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtCaptainHome);
				lblCaptainHome.Text = dtCaptainHome.Rows[0][1].ToString();
			}
			catch (Exception)
			{


			}
			try
			{
				DataTable dtStadium = new DataTable();
				sqlQuery = "SELECT team_name, home_stadium FROM team WHERE team_id = '" + cBoxTeamHome.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtStadium);
				lblStadium.Text = dtStadium.Rows[0][1].ToString();
			}
			catch (Exception)
			{


			}
			try
			{
				DataTable dtCapacity = new DataTable();
				sqlQuery = "SELECT team_name, capacity, home_stadium FROM team WHERE team_id = '" + cBoxTeamHome.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtCapacity);
				lblcapacity.Text = dtCapacity.Rows[0][1].ToString();
			}
			catch (Exception)
			{


			}


		}

		private void cBoxTeamAway_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DataTable dtManagerAway = new DataTable();
				sqlQuery = "SELECT manager.manager_id, manager.manager_name, team.team_id FROM manager,team WHERE manager.manager_id = '" + cBoxTeamAway.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtManagerAway);
				lblManagerAway.Text = dtManagerAway.Rows[0][1].ToString();
			}
			catch (Exception)
			{


			}
			try
			{
				DataTable dtCaptainAway = new DataTable();
				sqlQuery = "SELECT player.player_id, player.player_name, team.captain_id FROM player,team WHERE player.player_id = '" + cBoxTeamAway.SelectedValue.ToString() + "'";
				sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
				sqlAdapter = new MySqlDataAdapter(sqlCommand);
				sqlAdapter.Fill(dtCaptainAway);
				lblCaptainAway.Text = dtCaptainAway.Rows[0][1].ToString();
			}
			catch (Exception)
			{


			}

		}
	}
}
