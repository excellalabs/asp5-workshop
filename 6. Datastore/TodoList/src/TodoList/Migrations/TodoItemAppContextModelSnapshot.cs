using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using TodoList.Dal;

namespace TodoList.Migrations
{
    [ContextType(typeof(TodoItemAppContext))]
    partial class TodoItemAppContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("TodoList.Models.TodoItem", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<bool>("IsDone")
                            .Annotation("OriginalValueIndex", -1)
                            .Annotation("ShadowIndex", 1);
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("ShadowIndex", 2);
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}
