using SimpleSPAReact.Models;

namespace SimpleSPAReact.Data;

public class MyDataContext
{
    public List<PostModel> Posts { get; set; }

    public MyDataContext()
    {
        Posts = new List<PostModel>();
    }
}