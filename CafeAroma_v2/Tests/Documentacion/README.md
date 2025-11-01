# Documentación de Pruebas - CafeAroma_v2

Este directorio contiene la suite completa de pruebas unitarias, de integración y de patrones de diseño para el proyecto CafeAroma_v2.

## 📁 Estructura del Proyecto de Pruebas

```
Tests/
├── Entidades/                    # Pruebas de entidades del dominio
│   ├── GranoTests.cs            # Pruebas para la clase Grano
│   ├── ProductoTests.cs         # Pruebas para la clase Producto
│   └── LoteTests.cs             # Pruebas para la clase Lote
├── PatronesDeDiseno/            # Pruebas de patrones de diseño
│   ├── Factory/                 # Pruebas del patrón Factory
│   │   └── FabricaDeGranoTests.cs
│   ├── Singleton/               # Pruebas del patrón Singleton
│   │   └── GestorDelInventarioTests.cs
│   └── Command/                 # Pruebas del patrón Command
│       ├── AgregarGranoCommandTests.cs
│       └── AgregarProductoCommandTests.cs
├── BaseDeDatos/                 # Pruebas de acceso a datos
│   └── ConexionBDTests.cs       # Pruebas de conexión a base de datos
├── Integracion/                 # Pruebas de integración
│   └── IntegracionCommandsTests.cs
├── Configuracion/               # Configuración de pruebas
│   ├── Tests.runsettings        # Configuración de ejecución
│   └── TestConfig.cs            # Configuración global
├── Scripts/                     # Scripts de automatización
│   └── EjecutarPruebas.ps1      # Script PowerShell para ejecutar pruebas
└── Documentacion/              # Documentación
    ├── README.md               # Este archivo
    └── RESUMEN_PRUEBAS.md      # Resumen detallado de pruebas
```

## 🧪 Framework de Pruebas

- **Framework**: MSTest v3.1.1
- **Target Framework**: .NET Framework 4.8
- **Patrones Probados**: Factory, Singleton, Command
- **Cobertura**: Entidades, Patrones de Diseño, Integración, Base de Datos

## 🚀 Cómo Ejecutar las Pruebas

### Opción 1: Usando Visual Studio
1. Abrir la solución en Visual Studio
2. Ir a **Test** → **Run All Tests**
3. Usar el **Test Explorer** para ver resultados detallados

### Opción 2: Usando el Script PowerShell
```powershell
# Ejecutar todas las pruebas
.\Tests\Scripts\EjecutarPruebas.ps1

# Ejecutar solo pruebas de entidades
.\Tests\Scripts\EjecutarPruebas.ps1 -TipoPrueba Entidades

# Ejecutar con cobertura de código
.\Tests\Scripts\EjecutarPruebas.ps1 -ConCobertura

# Ejecutar con modo verbose
.\Tests\Scripts\EjecutarPruebas.ps1 -Verbose

# Generar reporte HTML
.\Tests\Scripts\EjecutarPruebas.ps1 -GenerarReporte
```

### Opción 3: Usando dotnet CLI
```bash
# Ejecutar todas las pruebas
dotnet test

# Ejecutar con configuración específica
dotnet test --settings Tests\Configuracion\Tests.runsettings

# Ejecutar con filtro
dotnet test --filter "FullyQualifiedName~Factory"
```

## 📊 Tipos de Pruebas Disponibles

### 1. Pruebas de Entidades (Tests/Entidades/)
- **GranoTests.cs**: 6 pruebas
  - Constructor parametrizado y sin parámetros
  - Modificación de propiedades
  - Validación de casos límite
  
- **ProductoTests.cs**: 8 pruebas
  - Constructores y propiedades
  - Validación de precios y cantidades
  - Casos con valores negativos y extremos
  
- **LoteTests.cs**: 8 pruebas
  - Gestión de fechas de vencimiento
  - Estados de lotes
  - Validación de IDs y números de lote

### 2. Pruebas de Patrones de Diseño (Tests/PatronesDeDiseno/)

#### Factory Pattern (Factory/)
- **FabricaDeGranoTests.cs**: 10 pruebas
  - Creación de granos Arábica con origen "Alta"
  - Creación de granos Robusta con origen "Estándar"
  - Manejo de tipos desconocidos con origen "Básica"
  - Validación de casos límite

#### Singleton Pattern (Singleton/)
- **GestorDelInventarioTests.cs**: 22 pruebas
  - Validación del patrón Singleton
  - Thread-safety
  - Gestión de inventario de granos y productos
  - Operaciones CRUD completas

#### Command Pattern (Command/)
- **AgregarGranoCommandTests.cs**: 15 pruebas
  - Ejecución y deshecho de comandos
  - Integración con GestorDelInventario
  - Casos con cantidades negativas y nulas
  
- **AgregarProductoCommandTests.cs**: 15 pruebas
  - Similar a granos pero para productos
  - Validación de precios y stocks
  - Operaciones reversibles

### 3. Pruebas de Base de Datos (Tests/BaseDeDatos/)
- **ConexionBDTests.cs**: 10 pruebas
  - Validación de conexiones
  - Ejecución de comandos y consultas
  - Manejo de recursos y timeouts

### 4. Pruebas de Integración (Tests/Integracion/)
- **IntegracionCommandsTests.cs**: 7 pruebas
  - Escenarios realistas de uso
  - Integración entre patrones Factory, Singleton y Command
  - Stress testing con múltiples operaciones
  - Verificación de consistencia global

## 📈 Estadísticas de Pruebas

- **Total de Pruebas**: 104
- **Pruebas de Entidades**: 22
- **Pruebas de Factory**: 10
- **Pruebas de Singleton**: 22
- **Pruebas de Command**: 30
- **Pruebas de Base de Datos**: 10
- **Pruebas de Integración**: 7
- **Pruebas de Configuración**: 3

## 🔧 Configuración

### Archivo Tests.runsettings
- Configuración de timeout: 5 minutos por sesión
- Configuración de cobertura de código
- Paralelismo configurado a nivel de clase
- Logging detallado habilitado
- Parámetros de prueba para diferentes ambientes

### Configuración Global (TestConfig.cs)
- Inicialización y limpieza global
- Configuración de cultura (es-ES)
- Datos de prueba consistentes
- Constantes reutilizables

## 🎯 Objetivos de las Pruebas

1. **Cobertura Completa**: Probar todas las funcionalidades principales
2. **Validación de Patrones**: Asegurar implementación correcta de patrones de diseño
3. **Casos Límite**: Validar comportamiento con datos extremos o inválidos
4. **Integración**: Verificar que los componentes funcionen juntos
5. **Rendimiento**: Stress testing para operaciones múltiples
6. **Consistencia**: Mantener estado coherente en todas las operaciones

## 🐛 Estrategias de Testing

### Arrange-Act-Assert (AAA)
Todas las pruebas siguen el patrón AAA:
- **Arrange**: Configurar datos y objetos necesarios
- **Act**: Ejecutar la operación a probar
- **Assert**: Verificar el resultado esperado

### Casos de Prueba
- **Happy Path**: Casos normales de uso
- **Edge Cases**: Valores límite y extremos
- **Error Cases**: Manejo de errores y excepciones
- **Integration**: Múltiples componentes trabajando juntos

## 📋 Convenciones de Naming

### Métodos de Prueba
```csharp
[TestMethod]
public void MetodoQueSePrueba_Condicion_ResultadoEsperado()
```

Ejemplos:
- `Constructor_ConParametrosValidos_DeberiaInicializarPropiedades()`
- `Ejecutar_ConGranoValido_DeberiaAgregarAlInventario()`
- `Deshacer_DespuesDeEjecutar_DeberiaQuitarDelInventario()`

### Clases de Prueba
- Sufijo `Tests` para todas las clases de prueba
- Mismo nombre que la clase probada + `Tests`
- Ejemplo: `Grano.cs` → `GranoTests.cs`

## 🔍 Análisis de Cobertura

El proyecto está configurado para generar reportes de cobertura de código:
- Incluye todos los archivos del proyecto principal
- Excluye archivos de prueba, recursos y código generado
- Excluye propiedades automáticas (getters/setters)
- Genera reportes en formato XML para análisis posterior

## 🚨 Troubleshooting

### Problemas Comunes

1. **Pruebas de Base de Datos Fallan**
   - Verificar que SQL Server esté ejecutándose
   - Actualizar cadena de conexión en TestConfig.cs
   - Las pruebas están diseñadas para funcionar sin BD en desarrollo

2. **Timeout en Pruebas**
   - Ajustar valores en Tests.runsettings
   - Verificar que no haya operaciones bloqueantes

3. **Pruebas Paralelas Fallan**
   - El GestorDelInventario se limpia entre pruebas
   - Verificar que no haya estado compartido no manejado

## 📚 Referencias

- [MSTest Documentation](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
- [.NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Design Patterns Testing](https://refactoring.guru/design-patterns)

## 📞 Soporte

Para preguntas sobre las pruebas o problemas de ejecución:
1. Revisar la documentación en `Tests/Documentacion/`
2. Ejecutar `.\Tests\Scripts\EjecutarPruebas.ps1 -Verbose` para más detalles
3. Verificar la configuración en `Tests/Configuracion/`

---

*Última actualización: Noviembre 2024*
