using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


public class global
{

    static global()
    {

    }

    public static int Login(string username, string password)
    {//输入帐号和密码，返回ID
        string sql = "select id from user where username=?username and password=?password";
        MySqlParameter[] p ={
    new MySqlParameter("?username",username),
    new MySqlParameter("?password",password)
                             };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        else return ((int)mysqlHelp.ExecuteScalar(sql, p));
    }

    public static int AddUser(string username, string password, string type)
    {//新增用户
        string permission = " 1";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string sql = "select username from user where username=?username";
        new MySqlParameter("?username", username);
        if (mysqlHelp.ExecuteNonQuery(sql) != 0) return -1;
        else
        {
            sql = "insert into user (username,password,type,permission,signupdate) values (?username,?password,?type,?permission,?signupdate)";
            MySqlParameter[] p ={
    new MySqlParameter("?username",username),
    new MySqlParameter("?password",password),
    new MySqlParameter("?type", type),
    new MySqlParameter("?permission", permission),
    new MySqlParameter("?signupdate", date)
                             };
            return (mysqlHelp.ExecuteNonQuery(sql, p));
        }
    }

    public static Int64 Usertype(int id)
    {//通过id找到用户类型 1为用户 2为管理员 3为评委
        string sql = "select type from participant where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return (Int64)mysqlHelp.ExecuteScalar(sql, p);
    }

    public static MySqlDataReader ParticipantInfo(int id)
    {//通过id找到参赛者个人详细信息
        string sql = "select * from participant where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        return mysqlHelp.ExecuteReader(sql, p);
    }

    public static int FindIdByUsername(string username)
    {
        //通过帐号找到用户,存在返回id，不存在返回-1；
        //缺少对username输入限制
        string sql = "select id from user where username=?username";
        MySqlParameter[] p ={
        new MySqlParameter("?username",username) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return -1;
        return (int)mysqlHelp.ExecuteScalar(sql, p);
    }

    public static DataTable FindParticipant(string realname)
    {
        //通过姓名找到个人资料
        string sql = "select id,realname,school,number from participant where realname=?realname";
        MySqlParameter[] p ={
        new MySqlParameter("?realname",realname) };
        return (mysqlHelp.ExecuteDataTable(sql, p));
    }

    public static MySqlDataReader CompetitionInfo(String id)
    {
        //显示比赛详情
        //加判断输入+是否存在
        string sql = "select * from competition where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        return mysqlHelp.ExecuteReader(sql, p);
    }

    public static MySqlDataReader com_hostInfo(String competition_id)
    {//通过赛事寻找主办方
     //加判断输入+是否存在
        string sql = "select * from launchcompetition where competition_id=?competition_id";
        MySqlParameter[] p ={
        new MySqlParameter("?competition_id",competition_id) };
        return mysqlHelp.ExecuteReader(sql, p);
    }

    public static MySqlDataReader HostInfo(int id)
    {//显示主办方个人信息
     //加判断输入+是否存在
        string sql = "select * from host where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        return mysqlHelp.ExecuteReader(sql, p);
    }

    public static Int64 VoteInfo(int team)
    {//显示投票数据
        string sql = "select count(*) from vote where team=?team";
        MySqlParameter[] p ={
        new MySqlParameter("?team",team) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return (Int64)mysqlHelp.ExecuteScalar(sql, p);
    }

    public static Int64 VotePeopleInfo(int team)
    {//显示投票数据
        string sql = "select count(*) from vote where team<>0";
        MySqlParameter[] p ={
        new MySqlParameter("?team",team) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return (Int64)mysqlHelp.ExecuteScalar(sql, p);
    }

    public static int isParticipantInfoExist(int id)
    {//显示参赛者信息    
        string sql = "select * from participant where id=?id";
        MySqlParameter[] p ={
         new MySqlParameter("?id",id) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        else return ((int)mysqlHelp.ExecuteScalar(sql, p));
    }

    private static string CreateId()
    {//随机生成一个ID
        long i = 1;
        foreach (byte b in Guid.NewGuid().ToByteArray())
        {
            i *= ((int)b + 1);
        }
        return string.Format("{0:x}", i - DateTime.Now.Ticks);
    }

    public static string CreateTeam()
    {//创建队伍
        string id = CreateId();
        string sql = "insert team (id) values (?id)";
        MySqlParameter[] p ={
                    new MySqlParameter("?id",id)
                   };
        if (mysqlHelp.ExecuteNonQuery(sql, p) == -1) return "-1";
        return id;
    }

    public static int JionTeam(string team_id, int paticipant_id)
    {//参与队伍        
        string date = DateTime.Now.ToString();
        string sql = "insert underling (participant_id,team_id,jointime)values(?participant_id,?team_id,?jointime)";
        MySqlParameter[] p ={
                    new MySqlParameter("?participant_id",paticipant_id),
                    new MySqlParameter("?team_id",team_id),
                    new MySqlParameter("?jointime",date),
                   };
        return mysqlHelp.ExecuteNonQuery(sql, p);
    }

    public static DataTable ShowTeamMenber(string team_id)
    {//展示队伍成员
        string sql = "select * from participant where id in (select participant_id from underling where team_id=?team_id)";
        MySqlParameter[] p ={
                    new MySqlParameter("?team_id",team_id),
                   };
        return mysqlHelp.ExecuteDataTable(sql, p);
    }

    public static int JoinCompetition(string competition_id, string team_id)
    {//参与比赛
        string signupdate = DateTime.Now.ToString();
        string sql = "insert takepartin (competition_id,team_id,signupdate)values(?competition_id,?team_id,?signupdate)";
        MySqlParameter[] p =
        {
            new MySqlParameter ("?competition_id",competition_id),
            new MySqlParameter("?team_id",team_id),
            new MySqlParameter ("?signupdate",signupdate)
        };
        if (mysqlHelp.ExecuteNonQuery(sql, p) == 0) return -1;
        return 1;
    }

    public static int Join(int id, string realname, string province, string city, string school, string major, string grade, string number, string email, string telephone, string wechat, string sex, string teachername, string teacherinfo, string competition_id)
    {
        //更新个人资料
        string sql2 = "update participant set realname=?realname,province=?province,city=?city,school=?school,major=?major,grade=?grade,number=?number,email=?email,telephone=?telephone,wechat=?wechat,sex=?sex where id=?id";
        MySqlParameter[] p ={
                new MySqlParameter("?id",id),
                new MySqlParameter("?realname",realname),
                new MySqlParameter("?province", province),
                new MySqlParameter("?city", city),
                new MySqlParameter("?school", school),
                new MySqlParameter("?major", major),
                new MySqlParameter("?grade",grade),
                new MySqlParameter("?number",number),
                new MySqlParameter("?email", email),
                new MySqlParameter("?telephone", telephone),
                new MySqlParameter("?wechat", wechat),
                new MySqlParameter("?sex", sex)
                                    };
        if (mysqlHelp.ExecuteNonQuery(sql2, p) == -1) return -1;

        //创建队伍，个人参赛视为队伍里只有他一个人
        string team_id = CreateId();
        string date = DateTime.Now.ToString();
        string sql = "insert team (id,teachername,teacherinfo)values(?id,?teachername,?teacherinfo)";
        MySqlParameter[] p3 ={
                    new MySqlParameter("?id",team_id),
                    new MySqlParameter("?teachername",teachername),
                    new MySqlParameter("?teacherinfo", teacherinfo) };
        if (mysqlHelp.ExecuteNonQuery(sql, p3) == -1) return -1;
        //加入队伍
        if (JionTeam(team_id, id) == -1) return -1;
        //参与比赛
        return (JoinCompetition(competition_id, team_id));

    }

    public static int UpdateTeam(string id, string teamname, string teaminfo, string teachername, string teacherinfo)
    {   //更新队伍信息  
        string sql = "update team set teamname=?teamname,teaminfo=?teaminfo,teachername=?teachername,teacherinfo=?teacherinfo where id=?id";
        MySqlParameter[] p =
        {
            new MySqlParameter ("?teamname",teamname),
            new MySqlParameter("?teaminfo",teaminfo),
            new MySqlParameter ("?teachername",teachername),
            new MySqlParameter ("?teacherinfo",teacherinfo),
            new MySqlParameter ("?id",id)
        };
        return (mysqlHelp.ExecuteNonQuery(sql, p));
    }

    public static DataTable ShowAllCompetition()
    {
        string sql = "SELECT * FROM competition,competitionstatus,launchcompetition,host,competitionlevel WHERE competition.id = launchcompetition.`competition_id`AND host.`id`= launchcompetition.`host_id` AND competition.status=competitionstatus.id";
        return (mysqlHelp.ExecuteDataTable(sql));
    }


    public static int isTeamnameExist(string competition_id, string teamname)
    {//显示参赛者信息    
        string sql = "SELECT * FROM competition,team,takepartin WHERE competition.id=takepartin.competition_id AND team.id=takepartin.team_id AND teamname=?teamname AND competition.id=?competition.id";
        MySqlParameter[] p ={
         new MySqlParameter("?competition.id",competition_id),
          new MySqlParameter("?teamname",teamname)
        };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return 1;
    }

    public static DateTime GetDateTime()
    {
        return DateTime.Now;
    }

    public static int AddNotice(string competition_id, string content)
    {
        string id = CreateId();
        DateTime date = GetDateTime();
        string sql = "insert into notice (id,competition_id,content,date) values (?id,?competition_id,?content,?date)";
        MySqlParameter[] p ={
         new MySqlParameter("?id",id),
         new MySqlParameter("?competition_id",competition_id),
         new MySqlParameter("?content",content),
         new MySqlParameter("?date",date),
        };
        if (mysqlHelp.ExecuteNonQuery(sql, p) == -1) return -1;
        sql = "INSERT INTO noticeread(notice_id, participant_id)SELECT notice.id, underling.`participant_id`FROM notice, takepartin, underling WHERE takepartin.`competition_id`= notice.`competition_id` AND underling.`team_id`=takepartin.`team_id` AND notice.id=?notice.id";
        MySqlParameter[] p1 ={
         new MySqlParameter("?notice.id",id) };
        if (mysqlHelp.ExecuteNonQuery(sql, p1) == -1) return -1;
        return 1;
    }

    public static Int64 NewNoticeNumber(int participant_id)
    {
        string sql = "select count(*) from noticeread where participant_id=?participant_id and noticeread.`read`=0";
        MySqlParameter[] p ={
         new MySqlParameter("?participant_id",participant_id)
        };

        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return (Int64)mysqlHelp.ExecuteScalar(sql, p);

    }

    public static int FindVoteId(string id)
    {
        //查找投票码是否存在,存在返回1，不存在返回0；
        string sql = "select * from vote where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        if (mysqlHelp.ExecuteScalar(sql, p) == null) return 0;
        return 1;
    }

    public static int IfHadVote(string id)
    {
        //查找投票码是否存在,存在返回1，不存在返回0；
        string sql = "select team from vote where id=?id";
        MySqlParameter[] p ={
        new MySqlParameter("?id",id) };
        if ((string)mysqlHelp.ExecuteScalar(sql, p) == "0") return 0;
        else return 1;
    }

    public static int Vote(string id, string team)
    {
        DateTime datetime = GetDateTime();
        string sql = "update vote set team=?team,datetime=?datetime where id=?id";
        MySqlParameter[] p ={
         new MySqlParameter("?id",id),
         new MySqlParameter("?team",team),
         new MySqlParameter("?datetime",datetime),
        };
        return (mysqlHelp.ExecuteNonQuery(sql, p));
    }

    }






















