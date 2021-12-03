class OrderFasade{
    constructor(){
        this.api_url = 'https://carserviceapi20211201175316.azurewebsites.net/api/repair';
    }
    async GetOrders(){
        let reponse = await fetch(this.api_url, {
            method: 'GET',
        });
        let data = await reponse.json();
        console.log(data)
        return data;
    }
}

export default OrderFasade;