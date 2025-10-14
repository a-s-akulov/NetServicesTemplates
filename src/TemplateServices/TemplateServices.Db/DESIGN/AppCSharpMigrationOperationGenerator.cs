using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace $safeprojectname$.Design;


public class AppCSharpMigrationOperationGenerator : CSharpMigrationOperationGenerator
{
    public AppCSharpMigrationOperationGenerator(CSharpMigrationOperationGeneratorDependencies dependencies)
        : base(dependencies)
    { }

    private const string WITH_NO_DB_FK_NAME = "with-no-db-fk";


    protected override void Generate(AddForeignKeyOperation operation, IndentedStringBuilder builder)
    {
        // Skip foreign key creation for relationships with no FK
        if (operation.Name == WITH_NO_DB_FK_NAME)
        {
            EmptyOperation(builder, "AddForeignKey");
            return;
        }
        
        base.Generate(operation, builder);
    }
    protected override void Generate(DropForeignKeyOperation operation, IndentedStringBuilder builder)
    {
        // Skip foreign key drop for relationships with no FK
        if (operation.Name == WITH_NO_DB_FK_NAME)
        {
            EmptyOperation(builder, "DropForeignKey");
            return;
        }
        
        base.Generate(operation, builder);
    }


    protected override void Generate(CreateTableOperation operation, IndentedStringBuilder builder)
    {
        var foreignKeysToRemove = operation.ForeignKeys
            .Where(x => x.Name == WITH_NO_DB_FK_NAME)
            .ToList();

        foreach (var foreignKeyToRemove in foreignKeysToRemove)
            operation.ForeignKeys.Remove(foreignKeyToRemove);

        base.Generate(operation, builder);
    }

    

    private IndentedStringBuilder EmptyOperation(IndentedStringBuilder builder, string operationName)
    {
        builder
            .AppendLine(".ActiveProvider?.ToString();")
            .Append($"// EMPTY OPERATION '{operationName}' CRUTCH /|\\    ");

        return builder;
    }
}
