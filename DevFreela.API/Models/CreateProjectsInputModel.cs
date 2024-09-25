﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class CreateProjectsInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
    
    public Project ToEntity()
    => new(Title, Description, IdClient, IdFreelancer, TotalCost);
}