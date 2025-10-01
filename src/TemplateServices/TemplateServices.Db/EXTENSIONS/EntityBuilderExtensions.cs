using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace $safeprojectname$.Extensions;


public static class EntityBuilderExtensions
{
    /// <summary>
    /// Don't create ForeignKey constraint in database
    /// </summary>
    public static ReferenceCollectionBuilder WithNoDatabaseForeignKey(this ReferenceCollectionBuilder referenceCollectionBuilder) =>
        referenceCollectionBuilder
            .HasConstraintName("with-no-db-fk")
            .OnDelete(DeleteBehavior.ClientNoAction);
    /// <inheritdoc cref="WithNoDatabaseForeignKey"/>
    public static ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity> WithNoDatabaseForeignKey<TPrincipalEntity, TDependentEntity>(this ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity> referenceCollectionBuilder)
        where TPrincipalEntity : class
        where TDependentEntity : class =>
        referenceCollectionBuilder
            .HasConstraintName("with-no-db-fk")
            .OnDelete(DeleteBehavior.ClientNoAction);
}
