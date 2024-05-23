﻿namespace Blog.Data.Repository;

public interface IBlogRepository
{
    public Task<List<Entities.Blog>?> GetAll();
    public Task<Entities.Blog> GetById(int id);
    public Task<Entities.Blog> GetByName(string name);
    public Task Add(Entities.Blog blog);
    public Task Update(Entities.Blog blog);
    public Task Delete(Entities.Blog blog);
}
