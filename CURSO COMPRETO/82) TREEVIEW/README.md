# TREEVIEW
Um `TreeView` em Windows Forms é um controle que permite exibir hierarquias de dados em forma de árvore. Ele é amplamente utilizado para representar estruturas de dados aninhadas, como diretórios de arquivos, categorias de produtos, entre outros. Aqui estão os principais pontos sobre como usar e personalizar um `TreeView` em uma aplicação Windows Forms:

## Funcionalidades Principais do TreeView:
1. **Hierarquia de Nós:**
   - O `TreeView` é composto por nós (`TreeNode`), que podem conter outros nós, permitindo criar uma estrutura hierárquica.
   - Cada nó pode ter um texto descritivo e uma imagem associada (opcionalmente).

2. **Manipulação de Nós:**
   - **Adicionar Nós:**
     ```csharp
     // Exemplo de adição de nós ao TreeView
     TreeNode parentNode = new TreeNode("Pasta Raiz");
     TreeNode childNode1 = new TreeNode("Subpasta 1");
     TreeNode childNode2 = new TreeNode("Subpasta 2");

     parentNode.Nodes.Add(childNode1);
     parentNode.Nodes.Add(childNode2);

     treeView1.Nodes.Add(parentNode); // Adiciona o nó raiz ao TreeView
     ```

   - **Seleção e Navegação:**
     ```csharp
     // Exemplo de seleção de nó e navegação
     TreeNode selectedNode = treeView1.SelectedNode;
     // Acessar os nós filhos de um nó específico
     foreach (TreeNode node in selectedNode.Nodes)
     {
         // Processar cada nó filho
     }
     ```

   - **Remoção de Nós:**
     ```csharp
     // Exemplo de remoção de um nó do TreeView
     TreeNode nodeToRemove = treeView1.Nodes[0]; // Primeiro nó
     treeView1.Nodes.Remove(nodeToRemove);
     ```

3. **Eventos Importantes:**
   - **AfterSelect:** Disparado após a seleção de um nó.
   - **NodeMouseClick:** Disparado quando um nó é clicado com o mouse.
   - **BeforeExpand, AfterExpand, BeforeCollapse, AfterCollapse:** Eventos relacionados à expansão e contração de nós.

   Exemplo de tratamento de evento `AfterSelect`:
   ```csharp
   private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
   {
       TreeNode selectedNode = e.Node;
       // Realizar ações com o nó selecionado
   }
   ```

4. **Personalização Visual:**
   - **Imagens nos Nós:** Você pode associar imagens aos nós para representar visualmente diferentes tipos de itens na árvore.
   - **Estilos de Fonte e Cor:** É possível personalizar a fonte e a cor do texto nos nós.

   Exemplo de configuração de imagens:
   ```csharp
   ImageList imageList = new ImageList();
   imageList.Images.Add("folder", Properties.Resources.FolderIcon);
   imageList.Images.Add("file", Properties.Resources.FileIcon);

   treeView1.ImageList = imageList;

   TreeNode node1 = new TreeNode("Pasta", 0, 0); // Usa a imagem de índice 0 (folder)
   TreeNode node2 = new TreeNode("Arquivo.txt", 1, 1); // Usa a imagem de índice 1 (file)

   treeView1.Nodes.Add(node1);
   treeView1.Nodes.Add(node2);
   ```

5. **Data Binding (Associação de Dados):**
   - O `TreeView` suporta associação de dados, permitindo ligar a hierarquia de nós diretamente a fontes de dados, como listas ou coleções.

## Considerações Adicionais:
- **Desempenho:** O desempenho do `TreeView` pode ser afetado em árvores muito grandes ou com muitos nós. Utilize técnicas como carregamento preguiçoso (`Lazy Loading`) para melhorar a performance.

- **Personalização Avançada:** É possível criar nós personalizados derivando da classe `TreeNode` para adicionar comportamentos ou dados adicionais.

- **Funcionalidades Avançadas:** O `TreeView` suporta funcionalidades como `CheckBoxes` nos nós, edição inline de texto, e outras personalizações avançadas através da manipulação de eventos e herança.

