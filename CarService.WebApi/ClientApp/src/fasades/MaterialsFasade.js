class MaterialsFasade{
    constructor(){
        this.api_url = "api/material";
    }

    async GetAll(){
        let reponse = await fetch(this.api_url);
        let data = await reponse.json();
        return data;
    }

    async GetById(id){
        let reponse = await fetch(this.api_url + "/" + id);
        let data = await reponse.json();
        return data;
    }

    async Create(auction_form_data){
        let reponse = await fetch(this.api_url, {
            method: 'POST',         
            body: auction_form_data
        });
        if (!reponse.ok){
            return false;
        }
        let data = await reponse.json();
        return data;
    }

    async Update(auction_form_data){
        let reponse = await fetch(this.api_url, {
            method: 'PUT',
            body: auction_form_data
        });
        let data = await reponse.text();
        console.log(data);
        return data;
    }
    async Delete(id){
        let reponse = await fetch(this.api_url + "/" + id, {
            method: 'DELETE',
        });
        return reponse.ok;
    }


   
}

export default MaterialsFasade;