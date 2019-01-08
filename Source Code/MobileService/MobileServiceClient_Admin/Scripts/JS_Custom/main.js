            function ValImg(x,y)
            {
                var file=x;
                var print=y;
                var arimg = ['.jpg','.png','.jpeg'];
                var des = document.getElementById(x).value;
                var position = des.lastIndexOf('.');
                var subDes = des.slice(position,);
                // document.getElementById('result').innerText = subDes + arimg[1];
                for (var i = 0; i < arimg.length; i++) {
                    if (subDes.toLowerCase()===arimg[i]) {
                        document.getElementById(print).innerText = "";
                        break;
                    } else {
                        document.getElementById(print).innerText = 'Error(*): File is not image';
                    }
                }
            }

            function valPass(x,y,z) {
                var a = document.getElementById(x).value;
                var b = document.getElementById(y).value;
                if (a!=b) {
                    document.getElementById(z).style.display = 'inline';
                    document.getElementById(z).innerText = 'Error(*): Password not same !';
                }else{
                    document.getElementById(z).innerText = '';
                }
            }
            

