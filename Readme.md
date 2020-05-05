# Create Deployment from yaml files in Minikube
1. Install `docker.io`, `kubectl`, `minikube`
2. Use `none` driver - https://minikube.sigs.k8s.io/docs/drivers/none \
fix `k8s 1.18 needs conntrack installed` with `sudo apt install conntrack`
3. `sudo minikube start --driver=none`\
`sudo minikube status`\
`sudo minikube stop`
4. Create Secret for gitlab registry, change credentials to your own\
`sudo kubectl create secret docker-registry gitlab-cred --docker-server=registry.gitlab.com --docker-username=drmckay-kirill --docker-password=<your-pword> --docker-email=drmckay-kirill@yandex.ru`\
`sudo kubectl get secret gitlab-cred --output=yaml`
5. Create ConfigMap\
`sudo kubectl create configmap my-api-conf --from-file=netk8s/yaml/my-api.properties`\
`sudo kubectl get configmaps my-api-conf -o yaml`
6. Create Deployment, change image name in file to your own\
`sudo kubectl create -f netk8s/yaml/my-api-deployment.yaml`\
Some commands:
`sudo kubectl get pods`\
`sudo kubectl describe pod <pod-name>`\
`sudo kubectl apply -f netk8s/yaml/my-api-deployment.yaml`\
`sudo kubectl get deploy`
7. Create service & ingress\
`minikube addons enable ingress`\
`sudo kubectl get pods -n kube-system`\
`sudo kubectl apply -f netk8s/yaml/my-api-service.yaml`\
`sudo kubectl get service my-api`\
`sudo minikube service my-api --url`\
`curl <service url>/api/Home`\
If you have DNS record, then put it to `my-api-ingress.yaml` instead of `my-api.io` and go to creating step\
`sudo minikube ip`\
Add to `/etc/hosts file` minikube ip and `my-api.io` url from ingress yaml\
Time to create ingress `sudo kubectl apply -f netk8s/yaml/my-api-ingress.yaml`\
`sudo kubectl get ingress`\
`curl my-api.io/api/Home`
8. Scale replics example\
`sudo kubectl scale deploy/my-api-deployment --replicas=8`\
`sudo kubectl rollout status deploy/my-api-deployment`\
`sudo kubectl scale deploy/my-api-deployment --replicas=5`


# GitLab CI/CD
1. Start local GitLab instance\
`sudo docker-compose up -d`
2. or use free GitLab (change GitLab URL to yours)\
`git remote add gitlab git@gitlab.com:drmckay-kirill/netk8s.git`\
`git push gitlab`
3. Go to Pipelines page and start manual build job\
Then check Registry page for new image