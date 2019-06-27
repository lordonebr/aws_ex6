var express = require('express');
var router = express.Router();

var vendas = [{
    id: 1,
    valor: 100,
    quantidade: 1,
    data: "01/06/2019",
    status: "ATIVA",
    produtos: {id:1, descricao: "produto 1", valor: 11} 
    },
    {
        id: 2,
        valor: 200,
        quantidade: 1,
        data: "02/06/2019",
        status: "ATIVA",
        produtos: {id:2, descricao: "produto 2", valor: 12} 
    
    },
    {
        id: 3,
        valor: 400,
        quantidade: 1,
        data: "02/06/2019",
        status: "CANCELADA",
        produtos: {id:2, descricao: "produto 3", valor: 20} 
    
    }
];

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('vendas', { vendas });
});

/* PUT home page. */
router.put('/:id', function(req, res, next) {
    const id = req.params.id;
    const mensagem = "Venda código "+id+" CANCELADA";
    res.render('vendas', { mensagem });
  });

/* POST home page. */
router.post('/', function(req, res, next) {
    const id = req.body.id;
    const valor = req.body.valor;
    const quantidade = req.body.quantidade;
    const data = req.body.data;
    const status = "ATIVA";
    const produtos = req.body.produtos;
    const venda = {id, valor, quantidade, data, status, produtos};
    vendas.push(venda);
    res.render('vendas', { vendas });
  });

module.exports = router;
