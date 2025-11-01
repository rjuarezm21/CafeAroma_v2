# Script de PowerShell para ejecutar pruebas de CafeAroma_v2
# Ejecutar como: .\EjecutarPruebas.ps1

param(
    [Parameter(Mandatory=$false)]
    [ValidateSet("Todas", "Unitarias", "Integracion", "Entidades", "Factory", "Singleton", "Command", "Database")]
    [string]$TipoPrueba = "Todas",
    
    [Parameter(Mandatory=$false)]
    [switch]$ConCobertura,
    
    [Parameter(Mandatory=$false)]
    [switch]$Verbose,
    
    [Parameter(Mandatory=$false)]
    [switch]$GenerarReporte
)

# Colores para la consola
function Write-ColoredText {
    param(
        [string]$Text,
        [ConsoleColor]$Color = "White"
    )
    Write-Host $Text -ForegroundColor $Color
}

# Banner inicial
Write-Host ""
Write-ColoredText "═══════════════════════════════════════════════════════════" "Cyan"
Write-ColoredText "        SUITE DE PRUEBAS - CAFEAROMA_V2" "Yellow"
Write-ColoredText "═══════════════════════════════════════════════════════════" "Cyan"
Write-Host ""

# Verificar que estamos en el directorio correcto
if (-not (Test-Path "CafeAroma_v2.csproj")) {
    Write-ColoredText "ERROR: No se encontró CafeAroma_v2.csproj" "Red"
    Write-ColoredText "Asegúrate de ejecutar este script desde el directorio del proyecto" "Red"
    exit 1
}

# Verificar que dotnet está disponible
try {
    $dotnetVersion = dotnet --version
    Write-ColoredText "✓ .NET CLI detectado: $dotnetVersion" "Green"
} catch {
    Write-ColoredText "ERROR: .NET CLI no está disponible" "Red"
    Write-ColoredText "Instalar .NET SDK: https://dotnet.microsoft.com/download" "Red"
    exit 1
}

Write-Host ""

# Construir el proyecto
Write-ColoredText "🔨 Construyendo proyecto..." "Yellow"
$buildResult = dotnet build --configuration Release --verbosity quiet
if ($LASTEXITCODE -ne 0) {
    Write-ColoredText "ERROR: Fallo en la construcción del proyecto" "Red"
    exit 1
}
Write-ColoredText "✓ Proyecto construido exitosamente" "Green"
Write-Host ""

# Determinar filtro de pruebas
$filter = ""
switch ($TipoPrueba) {
    "Unitarias" { $filter = "--filter TestCategory=Unitarias" }
    "Integracion" { $filter = "--filter TestCategory=Integracion" }
    "Entidades" { $filter = "--filter FullyQualifiedName~Entidades" }
    "Factory" { $filter = "--filter FullyQualifiedName~Factory" }
    "Singleton" { $filter = "--filter FullyQualifiedName~Singleton" }
    "Command" { $filter = "--filter FullyQualifiedName~Command" }
    "Database" { $filter = "--filter FullyQualifiedName~Database" }
    "Todas" { $filter = "" }
}

# Preparar argumentos para dotnet test
$testArgs = @("test")
if ($filter) { $testArgs += $filter.Split(' ') }
if ($ConCobertura) { $testArgs += "--collect:`"XPlat Code Coverage`"" }
if ($Verbose) { $testArgs += "--verbosity", "detailed" }
else { $testArgs += "--verbosity", "normal" }

# Agregar configuración de runsettings
$testArgs += "--settings", "Tests\Configuracion\Tests.runsettings"

# Mostrar configuración
Write-ColoredText "📋 Configuración de ejecución:" "Cyan"
Write-Host "   • Tipo de pruebas: $TipoPrueba"
if ($ConCobertura) { Write-Host "   • Cobertura de código: Habilitada" }
if ($Verbose) { Write-Host "   • Modo verbose: Habilitado" }
if ($GenerarReporte) { Write-Host "   • Generar reporte: Habilitado" }
Write-Host "   • Configuración: Tests\Configuracion\Tests.runsettings"
Write-Host ""

# Ejecutar pruebas
Write-ColoredText "🧪 Ejecutando pruebas..." "Yellow"
$startTime = Get-Date

# Ejecutar comando dotnet test
$testCommand = "dotnet " + ($testArgs -join " ")
Write-ColoredText "Comando: $testCommand" "Gray"
Write-Host ""

try {
    Invoke-Expression $testCommand
    $testExitCode = $LASTEXITCODE
} catch {
    Write-ColoredText "ERROR: Excepción durante la ejecución de pruebas" "Red"
    Write-ColoredText $_.Exception.Message "Red"
    exit 1
}

$endTime = Get-Date
$duration = $endTime - $startTime

Write-Host ""
Write-ColoredText "⏱️  Tiempo de ejecución: $($duration.ToString('mm\:ss'))" "Cyan"

# Analizar resultados
if ($testExitCode -eq 0) {
    Write-ColoredText "✅ TODAS LAS PRUEBAS PASARON" "Green"
    $exitMessage = "SUCCESS"
    $exitColor = "Green"
} else {
    Write-ColoredText "❌ ALGUNAS PRUEBAS FALLARON" "Red"
    $exitMessage = "FAILURE"
    $exitColor = "Red"
}

# Generar reporte si se solicitó
if ($GenerarReporte) {
    Write-Host ""
    Write-ColoredText "📊 Generando reporte de pruebas..." "Yellow"
    
    $reportPath = "TestResults\TestReport_$(Get-Date -Format 'yyyyMMdd_HHmmss').html"
    
    # Crear directorio si no existe
    if (-not (Test-Path "TestResults")) {
        New-Item -ItemType Directory -Path "TestResults" | Out-Null
    }
    
    # Generar reporte básico (placeholder - requiere herramientas adicionales para HTML completo)
    $reportContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Reporte de Pruebas - CafeAroma_v2</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .header { background-color: #f0f0f0; padding: 10px; border-radius: 5px; }
        .success { color: green; font-weight: bold; }
        .failure { color: red; font-weight: bold; }
        .info { color: blue; }
    </style>
</head>
<body>
    <div class="header">
        <h1>Reporte de Pruebas - CafeAroma_v2</h1>
        <p>Fecha: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')</p>
        <p>Tipo de pruebas: $TipoPrueba</p>
        <p>Duración: $($duration.ToString('mm\:ss'))</p>
        <p class="$($exitMessage.ToLower())">Estado: $exitMessage</p>
    </div>
    <h2>Configuración</h2>
    <ul>
        <li>Cobertura de código: $(if($ConCobertura){"Habilitada"}else{"Deshabilitada"})</li>
        <li>Modo verbose: $(if($Verbose){"Habilitado"}else{"Deshabilitado"})</li>
        <li>Filtro aplicado: $(if($filter){"$filter"}else{"Ninguno"})</li>
        <li>Configuración: Tests\Configuracion\Tests.runsettings</li>
    </ul>
    <h2>Comando Ejecutado</h2>
    <code>$testCommand</code>
    
    <h2>Notas</h2>
    <p>Para detalles completos, consultar la salida de consola o Test Explorer en Visual Studio.</p>
</body>
</html>
"@
    
    $reportContent | Out-File -FilePath $reportPath -Encoding UTF8
    Write-ColoredText "✓ Reporte generado: $reportPath" "Green"
}

# Mostrar información adicional
Write-Host ""
Write-ColoredText "📁 Ubicación de archivos de prueba:" "Cyan"
Write-Host "   • Tests\*.cs - Archivos de pruebas"
Write-Host "   • Tests\Documentacion\README.md - Documentación detallada"
if ($ConCobertura) {
    Write-Host "   • TestResults\ - Reportes de cobertura"
}

Write-Host ""
Write-ColoredText "💡 Comandos útiles:" "Cyan"
Write-Host "   • .\Tests\Scripts\EjecutarPruebas.ps1 -TipoPrueba Unitarias"
Write-Host "   • .\Tests\Scripts\EjecutarPruebas.ps1 -ConCobertura"
Write-Host "   • .\Tests\Scripts\EjecutarPruebas.ps1 -TipoPrueba Factory -Verbose"
Write-Host "   • .\Tests\Scripts\EjecutarPruebas.ps1 -GenerarReporte"

# Banner final
Write-Host ""
Write-ColoredText "═══════════════════════════════════════════════════════════" "Cyan"
Write-ColoredText "             EJECUCIÓN COMPLETADA: $exitMessage" $exitColor
Write-ColoredText "═══════════════════════════════════════════════════════════" "Cyan"
Write-Host ""

# Salir con el código de las pruebas
exit $testExitCode
