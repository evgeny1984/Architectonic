# Create and Publish Config

from inside k8s folder:
kubectl --kubeconfig .\base\cluster-kubeconfigs\local-kube.config kustomize ./overlays/test-env | kubectl --kubeconfig .\base\cluster-kubeconfigs\local-kube.config apply -f -


kubectl --kubeconfig .\base\clusters-kubeconfig\do-kube.config kustomize ./overlays/digitalocean | kubectl --kubeconfig .\base\clusters-kubeconfig\do-kube.config apply -f -
kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config kustomize ./overlays/azure | kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config apply -f -

kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config kustomize ./overlays/dyson | kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config apply -f -
kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config kustomize ./overlays/baxter | kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config apply -f -

___________________________________________________________________________________________________________________________________________________________________


# Show all running workloads
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config get deployments

# Show detailed info about the selected deployment
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config describe deployment rss-spa

# Update/Create pods
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config apply -f ./rr-gateway.yaml

# Get pods which all have the label
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config get pods -l workload.user.cattle.io/workloadselector=deployment-default-rr-gateway

# Get logs for pods with label
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config logs -l workload.user.cattle.io/workloadselector=deployment-default-rr-gateway

kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config get -o=wide deployments rss-spa

kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config get deployment --show-labels

# Show all running nodes on cluster
kubectl --kubeconfig .\base\clusters-kubeconfig\kube.config get nodes

# Kustomize approach

# Combine all yamls to one big file 
kubectl --kubeconfig .\base\cluster-kubeconfigs\local-kube.config kustomize ./overlays/test-env > do-all.yaml
kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config kustomize ./overlays/azure > az-all.yaml

# Apply the created file to the cluster
kubectl --kubeconfig .\base\clusters-kubeconfig\do-kube.config apply -f do-all.yaml
kubectl --kubeconfig .\base\clusters-kubeconfig\az-kube.config apply -f az-all.yaml

kubectl --kubeconfig .\base\clusters-kubeconfig\do-kube.config apply -f 
