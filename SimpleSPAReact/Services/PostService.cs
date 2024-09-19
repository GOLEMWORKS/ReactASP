using SimpleSPAReact.Data;
using SimpleSPAReact.Models;
using SimpleSPAReact.Services.Interfaces;

namespace SimpleSPAReact.Services;

public class PostService : IPostService
{
    private MyDataContext _dataContext;
    public PostService(MyDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public PostModel Create(PostModel model)
    {
        var lastPost = _dataContext.Posts.LastOrDefault();
        int newId = lastPost is null ? 1 : lastPost.Id + 1;
        
        model.Id = newId;
        _dataContext.Posts.Add(model);
        
        return model;
    }

    public PostModel Update(PostModel model)
    {
        var modelToUpdate = _dataContext.Posts.FirstOrDefault(p => p.Id == model.Id);
        modelToUpdate.Text = model.Text;
        modelToUpdate.Header = model.Header;
        
        return modelToUpdate;
    }

    public PostModel Get(int id)
    {
        return _dataContext.Posts.FirstOrDefault(p => p.Id == id);
    }

    public List<PostModel> Get()
    {
        return _dataContext.Posts.ToList();
    }

    public void Delete(int id)
    {
        var modelToDelete = _dataContext.Posts.FirstOrDefault(p => p.Id == id);
        _dataContext.Posts.Remove(modelToDelete);
    }
}