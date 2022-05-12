// See https://aka.ms/new-console-template for more information
using FluentSQLLib;
using Test.Models;

Console.WriteLine("Hello, World!");

var query = Select.From<Student>().Column(tbl => tbl.Name).Column(tbl=>tbl.Id);


