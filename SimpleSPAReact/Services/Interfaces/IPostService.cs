using SimpleSPAReact.Models;

namespace SimpleSPAReact.Services.Interfaces;

public interface IPostService
{
    PostModel Create(PostModel model);
    PostModel Update(PostModel model);
    PostModel Get(int id);
    List<PostModel> Get();
    void Delete(int id);
}