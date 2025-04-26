# AVL Tree Implementation in C#

![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Stable-brightgreen)

## Overview
Este repositorio contiene una implementación completa de árboles AVL (Adelson-Velsky y Landis) en C#. Los árboles AVL son árboles binarios de búsqueda autobalanceados donde la diferencia de altura entre subárboles izquierdo y derecho para cualquier nodo no puede ser más de uno.

## Características
- Implementación completa de árboles AVL en C#
- Operaciones básicas:
  - Inserción de nodos
  - Eliminación de nodos
  - Búsqueda de valores
  - Recorrido del árbol (inorder, preorder, postorder)
- Mantenimiento automático del balance del árbol mediante rotaciones
- Visualización de la estructura del árbol

## Requisitos
- .NET 8.0 o superior
- Visual Studio 2019/2022 o cualquier otro IDE compatible con C#

## Instalación
1. Clona este repositorio:
```bash
git clone https://github.com/Preko700/AVL.git
```
2. Abre el proyecto en tu IDE preferido
3. Compila la solución

## Uso
### Ejemplo básico

```csharp
// Crear un nuevo árbol AVL
AVLTree<int> tree = new AVLTree<int>();

// Insertar valores
tree.Insert(10);
tree.Insert(20);
tree.Insert(30);
tree.Insert(40);
tree.Insert(50);

// Buscar un valor
bool exists = tree.Search(30); // Devuelve true

// Eliminar un valor
tree.Delete(20);

// Recorrer el árbol
Console.WriteLine("Recorrido inorder:");
tree.InOrderTraversal();
```

## Estructura del proyecto
- `AVLTree.cs`: Clase principal que implementa el árbol AVL
- `Node.cs`: Clase que representa un nodo en el árbol

## Algoritmos implementados
- **Rotación simple a la izquierda**: Para casos de desequilibrio derecho-derecho
- **Rotación simple a la derecha**: Para casos de desequilibrio izquierdo-izquierdo
- **Rotación doble izquierda-derecha**: Para casos de desequilibrio izquierdo-derecho
- **Rotación doble derecha-izquierda**: Para casos de desequilibrio derecho-izquierdo

## Complejidad temporal
- Búsqueda: O(log n)
- Inserción: O(log n)
- Eliminación: O(log n)

## Contribuir
Las contribuciones son bienvenidas. Por favor, sigue estos pasos:
1. Fork el repositorio
2. Crea una nueva rama (`git checkout -b feature/nueva-caracteristica`)
3. Realiza tus cambios
4. Haz commit de tus cambios (`git commit -m 'Añadir nueva característica'`)
5. Haz push a la rama (`git push origin feature/nueva-caracteristica`)
6. Abre un Pull Request

## Licencia
Este proyecto está licenciado bajo la licencia Apache 2.0 - ver el archivo [LICENSE](LICENSE) para más detalles.

## Autor
[Adrian Monge Mairena](https://github.com/Preko700)

## Contacto
Si tienes alguna pregunta o sugerencia, no dudes en abrir un issue o contactarme directamente.
