﻿namespace Lab4.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly ValidUntil { get; set; }
}