// Author: Jan Škvařil (xskvar09)
class MaterialsFasade{
    constructor(){
        this.api_url = "api/material";
    }
    async GetDate(consumes_id){
        let reponse = await fetch("api/activity/getdate/" + consumes_id);
        let data = await reponse.text();
        return data;
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
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
              },     
            body: JSON.stringify(auction_form_data)
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
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
              },
            body: JSON.stringify(auction_form_data)
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