param(
    [Parameter(Mandatory=$true)]
    [string]$MigrationName
)

Write-Output "Running migration: $MigrationName"
dotnet ef migrations add $MigrationName --project Kma.Economy/ -o Data/Migrations