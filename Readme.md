# Create Deployment from yaml files in Minikube
1. Install `kubectl`
2. Install `minikube`
3. Use `none` driver - https://minikube.sigs.k8s.io/docs/drivers/none \
fix `k8s 1.18 needs conntrack installed` with `sudo apt install conntrack`
4. `sudo minikube start --driver=none`\
`sudo minikube status`\
`sudo minikube stop`
docker build -t registry.gitlab.com/drmckay-kirill/netk8s .
5. Create Secret for gitlab registry, change credentials to your own\
`kubectl create secret docker-registry gitlab-cred --docker-server=registry.gitlab.com/drmckay-kirill/netk8s --docker-username=drmckay-kirill --docker-password=<your-pword> --docker-email=drmckay-kirill@yandex.ru`\
`kubectl get secret gitlab-cred --output=yaml`
6. Create Deployment, change image name to your own\


# GitLab CI/CD
1. Start local GitLab instance\
`sudo docker-compose up -d`
2. or use free GitLab (change GitLab URL to yours)\
`git remote add gitlab git@gitlab.com:drmckay-kirill/netk8s.git`\
`git push gitlab`
3. Go to Pipelines page and start manual build job\
Then check Registry page for new image