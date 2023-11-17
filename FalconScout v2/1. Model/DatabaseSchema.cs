using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace T250DynoScout_v2023
{

    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    /* For possible future use
    public partial class Season : BaseEntity
    {
        public String  frcChampionship  { get; set; }
        public String  eventCount  { get; set; }
        public String  gameName  { get; set; }
        public String  kickoff  { get; set; }
        public String  rookieStart  { get; set; }
        public String  teamCount  { get; set; }
        public ICollection<Team> Teams { get; set; }  
    }
    */

    internal class SeasonContext : DbContext
    {
        public SeasonContext()
            : base("2023seasondb")
        { }

        public DbSet<EventSummary> Eventset { get; set; }
        public DbSet<TeamSummary> Teamset { get; set; }
        public DbSet<Match> Matchset { get; set; }
        public DbSet<Activity> ActivitySet { get; set; }
        public DbSet<ScoutedMatch> ScoutedMatchSet { get; set; }
        public DbSet<UpdatePreview> UpdatePreviewSet { get; set; }
    }

    public class MatchEvents
    {
        public string team;
        public string match;
        public string matchevent;
    }

    public class EventSummary : BaseEntity
    {
        public string key { get; set; }
        public string website { get; set; }
        public bool official { get; set; }
        public string end_date { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string facebook_eid { get; set; }
        public string event_district_string { get; set; }
        public string venue_address { get; set; }
        public int event_district { get; set; }
        public String week { get; set; }
        public string location { get; set; }
        public string event_code { get; set; }
        public int year { get; set; }
        public List<object> webcast { get; set; }
        public string timezone { get; set; }
        public List<object> alliances { get; set; }
        public string event_type_string { get; set; }
        public string start_date { get; set; }
        public int event_type { get; set; }
    }

    public class TeamSummary : BaseEntity
    {
        /* UNUSED DATA AVAILABLE FROM TBA
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string gmaps_place_id { get; set; }
        public string gmaps_url { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string location_name { get; set; }
        public string motto { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string postal_code { get; set; }
        public string rookie_year { get; set; }
        public string school_name { get; set; }
        public string state_prov { get; set; }
        public string website { get; set; }         */
        public string event_key { get; set; }
        public string team_key { get; set; }
        public string team_number { get; set; }
        public string nickname { get; set; }
        // Totals and trends for #2023
        public int matches { get; set; }
        public int scouted { get; set; }
        public string cone_top { get; set; }
        public string cone_mid { get; set; }
        public string cone_hyb { get; set; }
        public string cube_top { get; set; }
        public string cube_mid { get; set; }
        public string cube_hyb { get; set; }
        public string grid_out { get; set; }
        public string grid_coop { get; set; }
        public string auto_cones { get; set; }
        public string auto_cubes { get; set; }
        public int auto_pts { get; set; }
        public int m_auto_pts { get; set; }
        public int grid_pts { get; set; }
        public int m_grid_pts { get; set; }
        public int charge_pts { get; set; }
        public int m_charge_pts { get; set; }
        public string trend_setup { get; set; }
        public string trend_csauto { get; set; }
        public string trend_csend { get; set; }
        public string trend_cspartner { get; set; }
        public string trend_csfails { get; set; }
        public string trend_defense { get; set; }
        public string trend_avoidance { get; set; }
        public string trend_appstrat { get; set; }
        public double m_fouls { get; set; }
    }
    public class Match : BaseEntity
    {
        public string comp_level { get; set; }
        public int match_number { get; set; }
        public List<object> videos { get; set; }
        public object time_string { get; set; }
        public int set_number { get; set; }
        public string key { get; set; }
        public string time { get; set; }
        public string blueteam1 { get; set; }
        public string blueteam2 { get; set; }
        public string blueteam3 { get; set; }
        public string redteam1 { get; set; }
        public string redteam2 { get; set; }
        public string redteam3 { get; set; }
        public string event_key { get; set; }
        public int pointscorered { get; set; }
        public int redfouls { get; set; }
        public int pointscoreblue { get; set; }
        public int bluefouls { get; set; }
        public int blueauto { get; set; }
        public int redauto { get; set; }
        public int bluecharge { get; set; }
        public int redcharge { get; set; }
        public int bluetotaldel { get; set; }
        public int redtotaldel { get; set; }

    }

    public class Activity : BaseEntity
    {
        //Data elements used in multiple modes (Auto, Auto and/or Endgame)
        //Record Type = Transaction

        public string Team { get; set; }
        public int Match { get; set; }
        public DateTime Time { get; set; }
        public string RecordType { get; set; }
        public string Mode { get; set; }
        public int Mobility { get; set; }
        public int AcqSub1 { get; set; }
        public int AcqSub2 { get; set; }
        public int AcqFComm { get; set; }
        public int AcqFLoad { get; set; }
        public int AcqFOther { get; set; }
        public int AcqFOpps { get; set; }
        public int DelTop { get; set; }
        public int DelMid { get; set; }
        public int DelBot { get; set; }
        public int DelFloor { get; set; }
        public int DelOut { get; set; }
        public int DelCoop { get; set; }
        public int DelDrop { get; set; }
        public int Cone { get; set; }
        public int Cube { get; set; }
        public int No_Attempt { get; set; }
        public int Tried_And_Failed { get; set; }
        public int Parked { get; set; }
        public int Docked { get; set; }
        public int Engaged { get; set; }
        public int ChargePart { get; set; }
        public double EngageT { get; set; }
        public string EngageFail { get; set; }
        public int Setup { get; set; }
        public int AutoPts { get; set; }
        public int GridPts { get; set; }
        public int ChargePts { get; set; }
        public string ScouterName { get; set; }
        //public string ScouterNameAlt { get; set; }
        public int ScouterError { get; set; }
        public int Defense { get; set; }
        public int Avoidance { get; set; }
        public string Strategy { get; set; }
        public string match_event { get; set; }

        //Examples from previous years
        //public TimeSpan Cycle { get; set; }
        //public DateTime AcquireTime { get; set; }
        //public DateTime DeliverTime { get; set; }
        //public Decimal score_contribution { get; set; }
    }

    public class ScoutedMatch : BaseEntity
    {
        public string Team { get; set; }
        public int Match { get; set; }
    }

    public class UpdatePreview : BaseEntity
    {
        public string Team { get; set; }
        public int Match { get; set; }
        public DateTime Time { get; set; }
        public string RecordType { get; set; }
        public string Mode { get; set; }
        public int Mobility { get; set; }
        public int AcqSub1 { get; set; }
        public int AcqSub2 { get; set; }
        public int AcqFComm { get; set; }
        public int AcqFLoad { get; set; }
        public int AcqFOther { get; set; }
        public int AcqFOpps { get; set; }
        public int DelTop { get; set; }
        public int DelMid { get; set; }
        public int DelBot { get; set; }
        public int DelFloor { get; set; }
        public int DelOut { get; set; }
        public int DelCoop { get; set; }
        public int DelDrop { get; set; }
        public int Cone { get; set; }
        public int Cube { get; set; }
        public int No_Attempt { get; set; }
        public int Tried_And_Failed { get; set; }
        public int Parked { get; set; }
        public int Docked { get; set; }
        public int Engaged { get; set; }
        public int ChargePart { get; set; }
        public double EngageT { get; set; }
        public string EngageFail { get; set; }
        public int Setup { get; set; }
        public int AutoPts { get; set; }
        public int GridPts { get; set; }
        public int ChargePts { get; set; }
        public string ScouterName { get; set; }
        //public string ScouterNameAlt { get; set; }
        public int ScouterError { get; set; }
        public int Defense { get; set; }
        public int Avoidance { get; set; }
        public string Strategy { get; set; }
        public string match_event { get; set; }

    }
}