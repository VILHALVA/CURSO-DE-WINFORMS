# IMAGELIST
O controle `ImageList` em Windows Forms é usado para armazenar e gerenciar uma coleção de imagens que podem ser usadas por outros controles, como `ListView`, `TreeView`, `ToolStrip`, e outros, para exibir ícones e imagens.

Aqui está um exemplo básico de como usar o `ImageList`:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeuProjetoWinForms
{
    public partial class MeuFormulario : Form
    {
        private ImageList imageList1;
        private ListView listView1;

        public MeuFormulario()
        {
            InitializeComponent();

            // Criando um ImageList
            imageList1 = new ImageList();
            imageList1.Images.Add("icone1", Properties.Resources.icone1); // Adicionando uma imagem do recurso
            imageList1.Images.Add("icone2", Properties.Resources.icone2); // Adicionando outra imagem do recurso

            // Criando um ListView
            listView1 = new ListView();
            listView1.Location = new System.Drawing.Point(20, 20);
            listView1.Size = new System.Drawing.Size(300, 200);
            this.Controls.Add(listView1);

            // Associando o ImageList ao ListView
            listView1.LargeImageList = imageList1;

            // Adicionando itens ao ListView com imagens do ImageList
            listView1.Items.Add(new ListViewItem("Item 1", "icone1"));
            listView1.Items.Add(new ListViewItem("Item 2", "icone2"));
        }
    }
}
```

Neste exemplo:

- Criamos um `ImageList` chamado `imageList1`.
- Adicionamos duas imagens a este `ImageList` usando o método `Add`.
- Criamos um `ListView` chamado `listView1`.
- Associamos o `ImageList` ao `ListView` usando a propriedade `LargeImageList`.
- Adicionamos itens ao `ListView` e associamos esses itens às imagens no `ImageList`.

Principais propriedades e métodos do `ImageList`:

- **Images:** Coleção de imagens no `ImageList`.
- **ColorDepth:** Profundidade de cor das imagens no `ImageList` (`Depth8Bit`, `Depth16Bit`, `Depth24Bit`, `Depth32Bit`).
- **ImageSize:** Tamanho das imagens no `ImageList`.
- **TransparentColor:** Cor a ser tratada como transparente.
- **Add:** Adiciona uma imagem ao `ImageList`.
- **Remove:** Remove uma imagem do `ImageList`.

O `ImageList` é útil quando você precisa associar ícones ou imagens a itens em controles que suportam essa funcionalidade. Personalize o código conforme necessário para atender às necessidades específicas do seu aplicativo.