const baseAPIUrl = 'https://localhost:5001';

function customerService() {

    function uploadCustomersData(file) {
        const fd = new FormData()
        fd.append('file', file)
        console.log(baseAPIUrl);
        fetch(`${baseAPIUrl}/api/customer/upload`, {
            method: 'POST',
            body: fd,
        })
    }

    function getCustomersData() {
        console.log(baseAPIUrl);
        return fetch(`${baseAPIUrl}/api/customer`).then(data => data.json());
    };


    return {
        uploadCustomersData,
        getCustomersData,
    }
}

export default customerService;