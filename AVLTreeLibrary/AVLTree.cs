using System;
using System.Collections.Generic;

namespace AVLTreeLibrary
{
    // Implementación de un árbol AVL
    public class AVLTree
    {
        // El nodo raíz del árbol
        private AVLNode? _root; // Marcado como nullable para evitar problemas con null

        // Constructor para crear un nuevo árbol AVL vacío
        public AVLTree()
        {
            _root = null; // Permitido porque _root es nullable
        }

        // Obtiene la altura de un nodo específico
        private int Height(AVLNode? node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        // Calcula el factor de balance de un nodo
        private int GetBalance(AVLNode? node)
        {
            if (node == null)
                return 0;
            return Height(node.Left) - Height(node.Right);
        }

        // Realiza una rotación derecha en el subárbol con raíz en y
        private AVLNode RightRotate(AVLNode y)
        {
            // Verificar que y.Left no sea null antes de la rotación
            if (y.Left == null)
                throw new InvalidOperationException("Cannot perform right rotation when left child is null");

            AVLNode x = y.Left;
            AVLNode? T2 = x.Right;

            // Realizar la rotación
            x.Right = y;
            y.Left = T2;

            // Actualizar alturas
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            // Devolver la nueva raíz
            return x;
        }

        // Realiza una rotación izquierda en el subárbol con raíz en x
        private AVLNode LeftRotate(AVLNode x)
        {
            // Verificar que x.Right no sea null antes de la rotación
            if (x.Right == null)
                throw new InvalidOperationException("Cannot perform left rotation when right child is null");

            AVLNode y = x.Right;
            AVLNode? T2 = y.Left;

            // Realizar la rotación
            y.Left = x;
            x.Right = T2;

            // Actualizar alturas
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            // Devolver la nueva raíz
            return y;
        }

        // Inserta un valor en el árbol AVL
        public void Insert(int key)
        {
            _root = InsertRecursive(_root, key);
        }

        // Función recursiva para insertar una clave en el árbol
        private AVLNode InsertRecursive(AVLNode? node, int key)
        {
            // Inserción normal de BST
            if (node == null)
                return new AVLNode(key);

            if (key < node.Key)
                node.Left = InsertRecursive(node.Left, key);
            else if (key > node.Key)
                node.Right = InsertRecursive(node.Right, key);
            else // No se permiten claves duplicadas
                return node;

            // Actualizar la altura de este nodo ancestro
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            // Obtener el factor de balance de este nodo ancestro
            int balance = GetBalance(node);

            // Si el nodo se desequilibra, hay 4 casos

            // Caso Izquierda-Izquierda
            if (balance > 1 && node.Left != null && key < node.Left.Key)
                return RightRotate(node);

            // Caso Derecha-Derecha
            if (balance < -1 && node.Right != null && key > node.Right.Key)
                return LeftRotate(node);

            // Caso Izquierda-Derecha
            if (balance > 1 && node.Left != null && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Caso Derecha-Izquierda
            if (balance < -1 && node.Right != null && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            // Devolver el puntero del nodo sin cambios
            return node;
        }

        // Encuentra el nodo con el valor mínimo en un subárbol
        private AVLNode MinValueNode(AVLNode node)
        {
            AVLNode current = node;

            // Encontrar la hoja más a la izquierda
            while (current.Left != null)
                current = current.Left;

            return current;
        }

        // Elimina un valor del árbol AVL
        public void Delete(int key)
        {
            _root = DeleteRecursive(_root, key);
        }

        // Función recursiva para eliminar una clave del árbol
        private AVLNode? DeleteRecursive(AVLNode? root, int key)
        {
            // Paso 1: Realizar eliminación estándar de BST
            if (root == null)
                return null;

            // Si la clave a eliminar es menor que la clave de la raíz,
            // entonces está en el subárbol izquierdo
            if (key < root.Key)
                root.Left = DeleteRecursive(root.Left, key);

            // Si la clave a eliminar es mayor que la clave de la raíz,
            // entonces está en el subárbol derecho
            else if (key > root.Key)
                root.Right = DeleteRecursive(root.Right, key);

            // Si la clave es igual a la clave de la raíz, entonces este es el nodo
            // que debe ser eliminado
            else
            {
                // Nodo con un solo hijo o sin hijos
                if ((root.Left == null) || (root.Right == null))
                {
                    AVLNode? temp = root.Left ?? root.Right;

                    // Caso sin hijos
                    if (temp == null)
                    {
                        root = null;
                    }
                    else // Caso con un hijo
                    {
                        root = temp; // Copiar el contenido del hijo no nulo
                    }
                }
                else
                {
                    // Nodo con dos hijos: Obtener el sucesor inorden (el más pequeño
                    // en el subárbol derecho)
                    AVLNode temp = MinValueNode(root.Right);

                    // Copiar la clave del sucesor inorden a este nodo
                    root.Key = temp.Key;

                    // Eliminar el sucesor inorden
                    root.Right = DeleteRecursive(root.Right, temp.Key);
                }
            }

            // Si el árbol tenía solo un nodo, entonces retornar
            if (root == null)
                return null;

            // Paso 2: Actualizar la altura del nodo actual
            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            // Paso 3: Obtener el factor de balance de este nodo 
            // (para verificar si este nodo se ha desequilibrado)
            int balance = GetBalance(root);

            // Si el nodo se desequilibra, entonces hay 4 casos

            // Caso Izquierda-Izquierda
            if (balance > 1 && root.Left != null && GetBalance(root.Left) >= 0)
                return RightRotate(root);

            // Caso Izquierda-Derecha
            if (balance > 1 && root.Left != null && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Caso Derecha-Derecha
            if (balance < -1 && root.Right != null && GetBalance(root.Right) <= 0)
                return LeftRotate(root);

            // Caso Derecha-Izquierda
            if (balance < -1 && root.Right != null && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        // Busca un valor en el árbol AVL
        public bool Search(int key)
        {
            return SearchRecursive(_root, key);
        }

        // Función recursiva para buscar una clave en un subárbol
        private bool SearchRecursive(AVLNode? root, int key)
        {
            // Casos base: root es null o la clave está presente en root
            if (root == null)
                return false;
            if (root.Key == key)
                return true;

            // La clave es mayor que la clave de root
            if (root.Key < key)
                return SearchRecursive(root.Right, key);

            // La clave es menor que la clave de root
            return SearchRecursive(root.Left, key);
        }

        // Realiza un recorrido inorden en el árbol y devuelve los valores como un array
        public int[] InOrder()
        {
            List<int> result = new List<int>();
            InOrderRecursive(_root, result);
            return result.ToArray();
        }

        // Función auxiliar para recorrer el árbol en inorden
        private void InOrderRecursive(AVLNode? root, List<int> result)
        {
            if (root != null)
            {
                InOrderRecursive(root.Left, result);
                result.Add(root.Key);
                InOrderRecursive(root.Right, result);
            }
        }
    }
}
