# RECREATE
Este código em C# demonstra uma série de testes que exploram o comportamento de criação e recreação de handles (identificadores de janela) em aplicações Windows Forms, bem como o uso de formulários MDI (Multiple Document Interface) e controles personalizados.

## Explicação Detalhada:
### Classes e Métodos Principais:
1. **TortureControl**:
   - Herda da classe `Control` e define dois métodos públicos: `DoRecreateHandle()` e `DoCreateHandle()`.
   - `DoRecreateHandle()`: Chama o método `RecreateHandle()`, que força a recriação do handle do controle.
   - `DoCreateHandle()`: Chama o método `CreateHandle()`, que cria o handle para o controle, se ainda não existir.

2. **TortureMdiChild**:
   - Herda da classe `Form` e também define métodos `DoRecreateHandle()` e `DoCreateHandle()`.
   - Utiliza os mesmos métodos de `TortureControl`, mas aplicados a um formulário filho MDI (`Form` dentro de um formulário MDI).

3. **TortureMdiContainer**:
   - Herda da classe `Form` e configura `IsMdiContainer` como true no construtor.
   - Este formulário serve como um contêiner para formulários filhos MDI.

4. **TortureForm**:
   - Herda da classe `Form` e é o formulário principal que inicia a aplicação.
   - No construtor, configura o tamanho do formulário e adiciona um botão chamado "Run Tests".
   - Quando o botão é clicado (`RunTests`), uma série de testes são executados:
     - `TestNesting()`: Testa a criação e recreação de handles em controles aninhados.
     - `TestMdi()` e `TestMdi2()`: Testam a funcionalidade MDI ao abrir e fechar formulários filhos MDI.
     - `TestToplevel()` e `TestToplevel2()`: Testam a abertura de formulários toplevel (não MDI) e interações com botões dentro de um tempo limitado por um `Timer`.

5. **Método `Main`**:
   - O método principal que inicia a aplicação chamando `Application.Run(new TortureForm())`.

### Funcionalidade dos Testes:
- **TestNesting(level)**: Testa se a recreação do handle (`RecreateHandle()`) gera um novo identificador de janela (`Handle`) para controles aninhados até o nível especificado.
- **TestMdi() e TestMdi2()**: Testam a funcionalidade de formulários MDI, verificando se os formulários filhos podem interagir corretamente com o contêiner MDI e se podem ser fechados adequadamente após interação com um botão.
- **TestToplevel() e TestToplevel2()**: Testam a funcionalidade de formulários toplevel (não MDI), verificando se um botão dentro do formulário pode ser clicado dentro de um tempo limite definido pelo `Timer`.

### Uso de `Timer`:
- Os testes que envolvem a interação com o usuário possuem um `Timer` que é iniciado junto com a exibição de um formulário. Se o botão dentro do formulário não for clicado antes que o `Timer` expire, o teste falhará.

### Conclusão:
Este código não só ilustra como usar `RecreateHandle()` e `CreateHandle()` para gerenciar a criação e recreação de handles de controles em aplicações Windows Forms, mas também mostra como trabalhar com formulários MDI e toplevel, além de interações básicas com botões e temporizadores para testes de funcionalidade. Ele pode ser usado como base para entender melhor o ciclo de vida dos controles e formulários em aplicações desktop usando C#.