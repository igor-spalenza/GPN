
let abaContador = 1;
let qtdAbasAbertas = 0;

document.getElementById('btnAbrirPedido').addEventListener('click', () => {
    abaContador++;
    qtdAbasAbertas++;
    const pedidoId = `pedido${abaContador}`;

    // Criar a aba dinamicamente
    const novaAba = `
        <li class="nav-item" role="presentation">
            <button class="nav-link"
                    id="${pedidoId}-tab"
                    data-bs-toggle="tab"
                    data-bs-target="#${pedidoId}"
                    type="button"
                    role="tab">
                Novo Pedido
                <span class="btn-close ms-2" onclick="fecharAba('${pedidoId}')"></span>
            </button>
        </li>`;
    document.getElementById('pedidoTabs').insertAdjacentHTML('beforeend', novaAba);

    // Criar o conteúdo da aba e carregar a Partial View via AJAX
    const novoConteudo = `
        <div class="main-div tab-pane fade ${abaContador === 1 ? 'show active' : ''}"
             id="${pedidoId}"
             role="tabpanel">
            <div id="conteudo-${pedidoId}">Carregando...</div>
        </div>`;
    document.getElementById('pedidoTabsContent').insertAdjacentHTML('beforeend', novoConteudo);

    // Chamada AJAX para buscar a Partial View
    fetch('/Venda/NovoPedido')
        .then(response => response.text())
        .then(html => {
            document.getElementById(`conteudo-${pedidoId}`).innerHTML = html;
        })
        .catch(error => {
            document.getElementById(`conteudo-${pedidoId}`).innerHTML = '<p>Erro ao carregar o pedido.</p>';
            console.error('Erro ao carregar a partial view:', error);
        });

    // Ativar a nova aba automaticamente
    const tabTrigger = new bootstrap.Tab(document.getElementById(`${pedidoId}-tab`));
    tabTrigger.show();
});

document.getElementById('btnHomeVendas').addEventListener('click', () => {
    // 1. Remover as classes "active" e "show" de todas as abas ativas
    document.querySelectorAll('.tab-pane.active, .nav-link.active').forEach(element => {
        element.classList.remove('active', 'show');
    });

    // 2. Adicionar as classes "active" e "show" à aba principal
    const mainTab = document.getElementById('main-tab');
    mainTab.classList.add('active', 'show');

    // 3. Ativar a aba principal usando o Bootstrap Tab
    const tabTrigger = new bootstrap.Tab(document.querySelector('[data-bs-target="#main-tab"]'));
    tabTrigger.show();
});

function fecharAba(pedidoId) {
    const aba = document.getElementById(`${pedidoId}-tab`);
    const conteudo = document.getElementById(pedidoId);

    aba.remove();
    conteudo.remove();
    qtdAbasAbertas--;
    if (qtdAbasAbertas == 0) {
        const mainTab = document.getElementById('main-tab');
        mainTab.classList.add('active', 'show');
    }
}

function EditarPedido(IdPedido) {
    abaContador++;
    qtdAbasAbertas++;
    const pedidoId = `pedido${abaContador}`;

    // Criar a aba dinamicamente
    const novaAba = `
        <li class="nav-item" role="presentation">
            <button class="nav-link"
                    id="${pedidoId}-tab"
                    data-bs-toggle="tab"
                    data-bs-target="#${pedidoId}"
                    type="button"
                    role="tab">
                Novo Pedido
                <span class="btn-close ms-2" onclick="fecharAba('${pedidoId}')"></span>
            </button>
        </li>`;
    document.getElementById('pedidoTabs').insertAdjacentHTML('beforeend', novaAba);

    // Criar o conteúdo da aba e carregar a Partial View via AJAX
    const novoConteudo = `
        <div class="main-div tab-pane fade ${abaContador === 1 ? 'show active' : ''}"
             id="${pedidoId}"
             role="tabpanel">
            <div id="conteudo-${pedidoId}">Carregando...</div>
        </div>`;
    document.getElementById('pedidoTabsContent').insertAdjacentHTML('beforeend', novoConteudo);

    // Chamada AJAX para buscar a Partial View
    fetch('/Venda/EditPartial/'+IdPedido)
        .then(response => response.text())
        .then(html => {
            document.getElementById(`conteudo-${pedidoId}`).innerHTML = html;
        })
        .catch(error => {
            document.getElementById(`conteudo-${pedidoId}`).innerHTML = '<p>Erro ao carregar o pedido.</p>';
            console.error('Erro ao carregar a partial view:', error);
        });

    // Ativar a nova aba automaticamente
    const tabTrigger = new bootstrap.Tab(document.getElementById(`${pedidoId}-tab`));
    tabTrigger.show();
}
