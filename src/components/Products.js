import React, { useEffect, useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Button, ButtonBase, Container, Modal} from '@material-ui/core';
import EditPoductsModal from './EditPoductsModal';

const useStyles = makeStyles((theme) => ({
    table: {
        position: "static",
        width: "94%",
        overflow: "auto",
        marginTop: "1%",
        marginLeft: "3%",
        marginRight: "3%",
        borderCollapse: "collapse",
    },
    tableTrTd: {    
        borderTop: "2px solid #ccc",
        borderLeft: "2px solid #ccc",
        borderRight: "2px solid #ccc",
        borderBottom: "2px solid #ccc",
        textAlign: "center",
      },
      tableTh: {
          position: "static",
          fontSize: "130%",
          textAlign: "center",
          borderTop: "2px solid #ccc",
          borderLeft: "2px solid #ccc",
          borderRight: "2px solid #ccc",
      },
      captionTable: {
          fontSize: "150%",
          marginTop: "1%",
          marginBottom: "1%",
          textAlign: "center",
          fontWeight: "bold",
      },
      button: {
        margin: "5%",
      },
      class: {
        alignItems: 'center',
        justifyContent: 'center',
        transform: 'translate(-50%, -50%)',
        position: 'absolute',
        left: '50%',
        top: '50%',
        
        backgroundColor: theme.palette.background.paper,
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
}));

const Products = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [product_id, SetProductId] = useState([]);
    const [product_name, SetProductName] = useState([]);
    const [technical_specifications, SetTechnicalSpecifications] = useState([]);
    const [count_of_products, SetCountOfProducts] = useState([]);
    const [product_price, SetProductPrice] = useState([]);
    const [discount, SetDiscount] = useState([]);
    const [category_FK, SetCategoryFK] = useState([]);
    const classes = useStyles();
    const [open, setAdd] = React.useState(false);

    const handleCreate = () => {
        setAdd(true);
    };
    const handleClose = () => {
        setAdd(false);
    };

    const getCategories = () => {
        fetch("http://localhost:36964/api/Categories/")
            .then(response => response.json())
            .then(data => {
                setCategories(data);
            });
    }

    const getProducts = () => {
        fetch("http://localhost:36964/api/Products/")
            .then(response => response.json())
            .then(data => {
                setProducts(data);
            });
    }

    const deleteProducts = (product_id) =>
    {
        fetch("http://localhost:36964/api/Products/"+product_id, {
            method : 'DELETE',
            headers : {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json',
            },
            credentials: 'include'
        });        
    }

    const createProduct = (products) =>
    {
        fetch("http://localhost:36964/api/Products/",
        {
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({

                product_name: products.product_name,
                technical_specifications: products.technical_specifications,
                count_of_products: products.count_of_products,
                product_price: products.product_price,
                discount: products.discount,
                category_FK: products.category_FK,
            })
        })
        .then(response=>response.json());
    }

    useEffect(() => {

        getProducts();
    }, [])
    useEffect(() => {

        getCategories();
    }, [])

    const onSubmit = event => {
        event.preventDefault();
    }

    return (
        <div>
            <Button variant="outlined" color="primary" style={{position: "absolute" , left: "89%", top: "10%"}} onClick={handleCreate}>Добавить</Button>
            <Modal open={open}
            onClose={handleClose}>       

                <div id = "productDiv" className={classes.class} >
                <h2>Создать продукт</h2><br />    
                    <form>
                        <div className="form1_div">Название</div><input type="text" required name="product_name" onChange={e=>(SetProductName(e.target.value))} placeholder="Введите название" className="form1_input" /> <br />
                        <div className="form1_div">Характеристика</div><input type="text" required name="technical_specifications" onChange={e=>(SetTechnicalSpecifications(e.target.value))} placeholder="Введите характеристики" className="form1_input" /><br />
                        <div className="form1_div">Количество</div><input type="text" required name="count_of_products" value={count_of_products} onChange={e=>(SetCountOfProducts(e.target.value))} placeholder="Введите количество продукта" className="form1_input" /><br />
                        <div className="form1_div">Цена</div><input type="text" required name="product_price" value={product_price} onChange={e=>(SetProductPrice(e.target.value))} placeholder="Введите цену" className="form1_input" /><br />
                        <div className="form1_div">Скидка</div><input type="text" required name="discount" value={discount} onChange={e=>(SetDiscount(e.target.value))} placeholder="Укажите скидку" className="form1_input" /><br />
                        <div className="form1_div">Категория</div>
                        <select name="category" value={category_FK} onChange={e=>(SetCategoryFK(e.target.value))} className="form1_select">
                        {categories.map((category) =>
                            <option name="category_FK" value={category.category_id}>{category.category_name}</option>
                        )}
                        </select> <br />
                        <input id="createButton" type="submit" value="Применить" onClick={(e)=>{createProduct({product_id, product_name, technical_specifications, count_of_products, product_price, discount, category_FK}); {console.log(product_id)} return false;}} />
                        <br />
                    </form>
                </div>
            </Modal>

            <table className={classes.table}>
            <caption className={classes.captionTable}>Список продуктов</caption>
                <thead>
                    <tr>
                        <th className={classes.tableTh}>Название</th>
                        <th className={classes.tableTh}>Характеристики</th>
                        <th className={classes.tableTh}>Количество продуктов</th>
                        <th className={classes.tableTh}>Цена продукта</th>
                        <th className={classes.tableTh}>Скидка</th>
                        <th className={classes.tableTh}>Категория</th>
                        <th className={classes.tableTh}>Редактирование</th>
                    </tr>
                </thead>
                <tbody >
                    {products.map((product) =>
                        <tr>
                            <td className={classes.tableTrTd}>{product.product_name}</td>
                            <td className={classes.tableTrTd}>{product.technical_specifications}</td>
                            <td className={classes.tableTrTd}>{product.count_of_products}</td>
                            <td className={classes.tableTrTd}>{product.product_price} Рублей</td>
                            <td className={classes.tableTrTd}>{product.discount}%</td>
                            <td className={classes.tableTrTd}>{product.Category.category_name}</td>
                            <td className={classes.tableTrTd}>
                                <div>
                                    <ButtonBase style={{margin: "3%"}}>
                                        <EditPoductsModal EditedProducts={product}></EditPoductsModal>
                                    </ButtonBase>
                                    <Button style={{margin: "3%"}} variant="outlined" color="primary" onClick={(e)=>deleteProducts(product.product_id)}>Удалить</Button>
                                </div>
                            </td> 
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    ); 
}
export default Products