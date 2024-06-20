# ICON
Em aplicações Windows Forms, o ícone (ou icon) refere-se à imagem que representa o aplicativo na barra de título da janela, na barra de tarefas e em outros locais do sistema operacional. Vamos explorar como você pode definir um ícone para seu aplicativo Windows Forms:

## Definindo um Ícone para seu Aplicativo
Para definir um ícone personalizado para seu aplicativo Windows Forms, você precisa seguir os seguintes passos:

1. **Preparação do Ícone**:
   - Primeiramente, você precisa ter um arquivo de ícone (extensão .ico) pronto. Este arquivo pode ser criado utilizando ferramentas de edição de imagens, como o Microsoft Paint, ou utilizando software específico para criação de ícones.

2. **Inclusão do Ícone no Projeto**:
   - Depois de criar seu arquivo .ico, adicione-o ao projeto. Para isso, siga os passos abaixo:
     - No Visual Studio, clique com o botão direito sobre o seu projeto na janela "Solution Explorer".
     - Escolha "Add" (Adicionar) e depois "Existing Item" (Item Existente).
     - Navegue até o local onde está seu arquivo .ico e selecione-o para inclusão no projeto.

3. **Configuração do Ícone na Propriedade do Formulário**:
   - Agora, você precisa configurar o ícone para ser exibido na sua janela principal (Formulário). Para isso, siga estes passos:
     - Abra o formulário principal (geralmente chamado de `Form1.cs` ou similar) no designer.
     - Na janela de propriedades do formulário (Properties), encontre a propriedade `Icon` e clique no botão de elipse (`...`).

4. **Seleção do Ícone**:
   - Uma janela será aberta, mostrando os ícones disponíveis no seu projeto. Se você adicionou o ícone corretamente como um item no projeto, ele deverá aparecer nesta lista.
   - Selecione o ícone desejado e clique em "OK" para aplicá-lo ao seu formulário.

5. **Compilação e Execução**:
   - Compile seu projeto. O ícone selecionado será exibido na barra de título do formulário, na barra de tarefas e também será utilizado como ícone do executável gerado.

## Exemplo Prático
Suponha que você tenha um ícone chamado `myIcon.ico` adicionado ao seu projeto. Aqui está como você configuraria o ícone para o formulário principal:

```csharp
using System;
using System.Windows.Forms;

namespace IconExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código adicional que você queira executar quando o formulário é carregado
        }
    }
}
```

## Observações
- Certifique-se de que o arquivo .ico está configurado corretamente nas propriedades do projeto para que seja incorporado ao executável quando o projeto for compilado.
- Utilizar um ícone adequado pode melhorar a identidade visual do seu aplicativo e facilitar a identificação na barra de tarefas e no sistema operacional.

Seguindo esses passos, você será capaz de definir e utilizar um ícone personalizado para seu aplicativo Windows Forms de forma simples e eficaz.