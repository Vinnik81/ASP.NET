public class Result
{
    public int id { get; set; }
    public string type { get; set; }
    public User_Data user_data { get; set; }
    public int? master_id { get; set; }
    public string master_url { get; set; }
    public string uri { get; set; }
    public string title { get; set; }
    public string thumb { get; set; }
    public string cover_image { get; set; }
    public string resource_url { get; set; }
    public string country { get; set; }
    public string year { get; set; }
    public string[] format { get; set; }
    public string[] label { get; set; }
    public string[] genre { get; set; }
    public string[] style { get; set; }
    public string[] barcode { get; set; }
    public string catno { get; set; }
    public Community community { get; set; }
    public int format_quantity { get; set; }
    public Format[] formats { get; set; }
}
